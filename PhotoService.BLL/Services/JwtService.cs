using Microsoft.IdentityModel.Tokens;
using PhotoService.BLL.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PhotoService.BLL.Services
{
    public class JwtService : IJwtService
    {
        public string CreateToken(string key, string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenKey = Encoding.ASCII.GetBytes(key);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, email)
                }),

                Expires = DateTime.UtcNow.AddDays(1),

                SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(tokenKey),
                        SecurityAlgorithms.HmacSha256Signature
                    )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
