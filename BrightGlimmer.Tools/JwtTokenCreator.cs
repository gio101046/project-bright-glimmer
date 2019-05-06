using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BrightGlimmer.Tools
{
    /* TODO: WIP */
    public class JwtTokenCreator
    {
        private readonly string privateKey;

        public JwtTokenCreator(string privateKey)
        {
            this.privateKey = privateKey;
        }

        public string CreateToken(string username, string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(privateKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, username),
                    new Claim(ClaimTypes.Email, email)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenSecurity = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(tokenSecurity);

            return token;
        }
    }
}
