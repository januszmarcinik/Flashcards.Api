using Flashcards.Core.Extensions;
using Flashcards.Core.Settings;
using Flashcards.Domain.Enums;
using Flashcards.Infrastructure.Dto.Tokens;
using Flashcards.Infrastructure.Managers.Abstract;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Flashcards.Infrastructure.Managers.Concrete
{
    internal class JwtManager : IJwtManager
    {
        private JwtSettings _jwtSettings;

        public JwtManager(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        public JwtDto CreateToken(string email, Role role)
        {
            var now = DateTime.UtcNow;
            var claims = new Claim[]
            {
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
