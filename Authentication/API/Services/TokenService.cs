using System.IdentityModel.Tokens.Jwt;
using System.Text;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    public class TokenService
    {
        public static string GenerateToken(User user) 
        {
           var tokenHandler = new JwtSecurityTokenHandler();
           var key = Encoding.ASCII.GetBytes(Settings.Secret);
           var tokenDescriptor = new SecurityTokenDescriptor {
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
           };
           var token = tokenHandler.CreateToken(tokenDescriptor);
           return tokenHandler.WriteToken(token);
        }
    }
}