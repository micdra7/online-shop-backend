using System;
using System.Security.Cryptography;

namespace online_shop_backend.Utils
{
    public class TokenFactory
    {
        public static string GenerateToken(int size = 32)
        {
            var randomNum = new byte[size];

            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNum);
            
            return Convert.ToBase64String(randomNum);
        }
    }
}