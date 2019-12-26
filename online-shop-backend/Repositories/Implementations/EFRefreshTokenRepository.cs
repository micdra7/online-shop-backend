using System;
using System.Linq;
using online_shop_backend.Models.Entities;
using online_shop_backend.Models.Identity;
using online_shop_backend.Repositories.Interfaces;

namespace online_shop_backend.Repositories.Implementations
{
    public class EFRefreshTokenRepository : IRefreshTokenRepository
    {
        private ApplicationDbContext context;

        public EFRefreshTokenRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        public void AddRefreshToken(RefreshToken refreshToken)
        {
            context.RefreshTokens.Add(refreshToken);
            context.SaveChanges();
        }

        public void RemoveRefreshToken(RefreshToken refreshToken)
        {
            context.RefreshTokens.Remove(refreshToken);
            context.SaveChanges();
        }

        public bool IsRefreshTokenActive(RefreshToken refreshToken)
        {
            return DateTime.Now <= context.RefreshTokens
                .First(rt => rt.Token == refreshToken.Token)
                .ExpiryDate;
        }

        public bool IsRefreshTokenActive(string refreshToken)
        {
            return DateTime.Now <= context.RefreshTokens
                .First(rt => rt.Token == refreshToken)
                .ExpiryDate;
        }
    }
}