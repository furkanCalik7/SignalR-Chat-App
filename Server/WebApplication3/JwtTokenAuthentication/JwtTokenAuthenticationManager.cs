using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication3.JwtTokenAuthentication {
    public class JwtTokenAuthenticationManager : IJwtTokenAuthenticationManager {

        public IDictionary<string, string> users = new Dictionary<string, string> {
            {"user1", "password1"},
            {"user2", "password2"}
        };
       
        public readonly string securityKey;

        public JwtTokenAuthenticationManager(string securityKey) {
            this.securityKey = securityKey;
        }

        public string Authenticate(string username, string password) {

            if (!users.Any(u => u.Key == username && u.Value == password)) {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(securityKey);
            
            // TODO: Remove
            Console.WriteLine("TokenKey: " + tokenKey);

            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = 
                new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
