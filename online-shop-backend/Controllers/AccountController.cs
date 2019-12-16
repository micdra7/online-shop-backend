using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public AccountController(UserManager<ApplicationUser> userManager, IRefreshTokenRepository refreshTokenRepository)
        {
            this.userManager = userManager;
            this.refreshTokenRepository = refreshTokenRepository;
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
            }

            return BadRequest("Error while logging in. Please try later.");
        }
        
    }
}