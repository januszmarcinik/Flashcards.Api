﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Flashcards.Application.Users;
using Flashcards.Core.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Flashcards.Application.Tokens
{
    internal class JwtTokenService : ITokenService
    {
        private readonly JwtSettings _jwtSettings;

        public JwtTokenService(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
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
                    new Claim(JwtRegisteredClaimNames.Iat, now.GetTimeStamp().ToString(), ClaimValueTypes.Integer64)
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
    }
}
