using IKPro.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IKPro.Application.Services.TokenServis
{
    public class TokenServis : ITokenServis
    {
        private readonly IConfiguration _config;

        public TokenServis(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(string email, string role, int id,AppUser user)
        {
            string sirket=Convert.ToString(user.SirketID);
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role),
                new Claim(ClaimTypes.UserData,sirket),
                new Claim(ClaimTypes.NameIdentifier, id.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:SecretKey"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["JwtSettings:Issuer"],
                audience: _config["JwtSettings:Audience"],
                claims: authClaims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: signIn
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

