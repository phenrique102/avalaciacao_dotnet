using Application.Interfaces;
using Domain.Usuarios;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services
{
    public class PatternAuthenticationService(IConfiguration configuration) : IPatternAuthenticationService
    {
        public Token GerarToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["PatternToken:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                [
                    new Claim(ClaimTypes.Name, usuario.DsNome),
                    new Claim(ClaimTypes.Email, usuario.DsEmail)
                ]),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = configuration["PatternToken:Issuer"],
                Audience = configuration["PatternToken:Audience"]
            };
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);
            return new Token
            {
                AccessToken = token,
                TokenType = "Bearer",
                Expires = tokenDescriptor.Expires.Value
            };
        }
    }
}
