namespace online_shop_backend.Models.DTO
{
    public class RefreshTokenDTO
    {
        public string RefreshToken { get; set; }
        public UserDTO User { get; set; }
    }
}