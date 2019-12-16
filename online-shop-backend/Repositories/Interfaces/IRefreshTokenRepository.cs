using online_shop_backend.Models.Entities;

namespace online_shop_backend.Repositories.Interfaces
{
    public interface IRefreshTokenRepository
    {
        void AddRefreshToken(RefreshToken refreshToken);
        void RemoveRefreshToken(RefreshToken refreshToken);
        bool IsRefreshTokenActive(RefreshToken refreshToken);
        bool IsRefreshTokenActive(string refreshToken);
    }
}