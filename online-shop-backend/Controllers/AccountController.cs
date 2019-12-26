using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using online_shop_backend.Models.DTO;
using online_shop_backend.Models.Entities;
using online_shop_backend.Models.Identity;
using online_shop_backend.Repositories.Interfaces;
using online_shop_backend.Utils;

namespace online_shop_backend.Controllers
{
    [Route("/api/account")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IRefreshTokenRepository refreshTokenRepository;
        private readonly IConfiguration configuration;

        public AccountController(UserManager<ApplicationUser> userManager, IRefreshTokenRepository refreshTokenRepository,
            IConfiguration configuration)
        {
            this.userManager = userManager;
            this.refreshTokenRepository = refreshTokenRepository;
            this.configuration = configuration;
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var userToAdd = new ApplicationUser
            {
                UserName = user.Username,
                Email = user.Email,
                Details = new List<UserDetail>
                {
                    new UserDetail
                    {
                        Name = user.Name,
                        Surname = user.Surname
                    }
                }
            };

            var result = await userManager.CreateAsync(userToAdd, user.Password);

            await userManager.AddToRoleAsync(userToAdd, Constants.USER);

            return result.Succeeded ? 
                Ok(IdentityResult.Success) as IActionResult : 
                BadRequest(IdentityResult.Failed(result.Errors as IdentityError[]));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDTO userDto)
        {
            if (string.IsNullOrEmpty(userDto.Username) || string.IsNullOrEmpty(userDto.Password))
            {
                return BadRequest("Username/password cannot be empty");
            }
            
            var user = await userManager.FindByNameAsync(userDto.Username);

            if (user != null && await userManager.CheckPasswordAsync(user, userDto.Password))
            {
                var refreshToken = TokenFactory.GenerateToken();
                
                refreshTokenRepository.AddRefreshToken(
                    new RefreshToken
                    {
                        Token = refreshToken, 
                        ApplicationUserID = user.Id, 
                        ExpiryDate = DateTime.Now.AddDays(5)
                    });

                var jwt = await GenerateJwt(user);

                return Ok(new {jwt, refreshToken});
            }

            return BadRequest("Error while logging in. Please try later.");
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshTokenDTO tokenDto)
        {
            if (refreshTokenRepository.IsRefreshTokenActive(tokenDto.RefreshToken))
            {
                var user = await userManager.FindByNameAsync(tokenDto.User.Username);
                var jwt = await GenerateJwt(user);

                return Ok(new {jwt, tokenDto.RefreshToken});
            }

            return BadRequest("Invalid refresh token");
        }

        private async Task<string> GenerateJwt(ApplicationUser user)
        {
            var identity = new ClaimsIdentity(
                new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName)
                });
            
            var secretKey = Encoding.ASCII.GetBytes(configuration["SecretKey"]);

            var claims = (await userManager.GetRolesAsync(user))
                .Select(r => new Claim(ClaimTypes.Role, r));

            var token = new JwtSecurityToken(configuration["Issuer"],  configuration["Issuer"],
                claims, null, DateTime.UtcNow.AddHours(6), new SigningCredentials(
                    new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        
    }
}