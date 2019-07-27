using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Flashcards.Core.Extensions;
using Flashcards.Domain.Enums;
using Flashcards.Domain.Services;
using Flashcards.Infrastructure.Settings;
using Microsoft.IdentityModel.Tokens;

namespace Flashcards.Infrastructure.Services
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
            var claims = new []
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, id.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(ClaimTypes.Role, role.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToTimeStamp().ToString(), ClaimValueTypes.Integer64)
            };

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)), SecurityAlgorithms.HmacSha256);
            var expires = now.AddMinutes(_jwtSettings.ExpiryMinutes);

            var jwt = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                claims: claims,
                notBefore: now,
                expires: expires,
                signingCredentials: signingCredentials);

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JwtDto()
            {
                Token = token,
                Expiry = expires
            };
        }
    }
}
