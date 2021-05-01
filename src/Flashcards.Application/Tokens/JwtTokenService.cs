using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Flashcards.Application.Users;
using Microsoft.IdentityModel.Tokens;

namespace Flashcards.Application.Tokens
{
    internal class JwtTokenService : ITokenService
    {
        private readonly JwtSettings _jwtSettings;

        public JwtTokenService(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        public JwtDto CreateToken(Guid id, string email, Role role)
        {
            var now = DateTime.UtcNow;
            var expires = now.AddMinutes(_jwtSettings.ExpiryMinutes);
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new []
                {
                    new Claim(JwtRegisteredClaimNames.UniqueName, id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, email),
                    new Claim(ClaimTypes.Role, role.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, GetTimeStamp(now).ToString(), ClaimValueTypes.Integer64)
                }),
                Expires = expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _jwtSettings.Issuer,
                NotBefore = now
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new JwtDto
            {
                Token = tokenHandler.WriteToken(token),
                Expiry = expires
            };
        }
        
        private static long GetTimeStamp(DateTime dateTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var time = dateTime.Subtract(new TimeSpan(epoch.Ticks));

            return time.Ticks / 10000;
        }
    }
}
