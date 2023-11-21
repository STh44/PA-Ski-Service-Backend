using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SkiServiceBackend.Services;

namespace SkiServiceBackend.Services
{
    public class TokenService : ITokenService
    {
        
        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration config)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
        }

        /// <summary>
        /// Erstellt einen JWT-Token für den angegebenen Benutzernamen.
        /// </summary>
        /// <param name="username">Der Benutzername.</param>
        /// <returns>Der erstellte JWT-Token.</returns>
        public string CreateToken(string username)
        {
           
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, username)
            };


            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            // Erstellen der Token-Beschreibung
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            // Rückgabe des erstellten Tokens
            return tokenHandler.WriteToken(token);
        }
    }
}
