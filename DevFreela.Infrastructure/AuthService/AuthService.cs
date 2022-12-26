using System;
using DevFreela.Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DevFreela.Infrastructure.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration configuration;

        public AuthService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GenerateJwtToken(string email, string role)
        {
            var issuer = configuration["Jwt:Issuer"];
            var audience = configuration["Jwt:Audience"];
            var key = configuration["Jwt:Key"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credencials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim("userName", email),
                new Claim(ClaimTypes.Role, role)
            };

            var token =
                new JwtSecurityToken(
                    issuer: issuer,
                    audience: audience,
                    expires: DateTime.Now.AddHours(8),
                    signingCredentials: credencials,
                    claims: claims);

            var tokenHandler = new JwtSecurityTokenHandler();

            var stringToken = tokenHandler.WriteToken(token);

            return stringToken;
        }
    }
}