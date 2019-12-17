using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TakeCourses.Core.Contracts.Services;
using TakeCourses.Core.Entities.Dtos.ConfigurationDto;
using TakeCourses.Core.Entities.Entities;
using TakeCourses.InfraStructures.Tools.Helpers;

namespace TakeCourses.Core.Services
{
    public class JwtTokenService : ITokenService
    {
        private readonly JwtSettingsDto JwtSettings;

        public JwtTokenService(IOptionsSnapshot<JwtSettingsDto> _JwtSettings)
        {
            this.JwtSettings = _JwtSettings.Value;
        }

        public async Task<string> GenerateToken(User user)
        {
            var secretKey = StringHelper.StringToByteArray(JwtSettings.SecretKey);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature);

            var encryptionkey = StringHelper.StringToByteArray(JwtSettings.Encryptkey);
            var encryptingCredentials = new EncryptingCredentials(new SymmetricSecurityKey(encryptionkey), SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256);

            var claims = await GetClaims(user);

            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = JwtSettings.Issuer,
                Audience = JwtSettings.Audience,
                IssuedAt = DateTime.Now,
                NotBefore = DateTime.Now.AddMinutes(JwtSettings.NotBeforeMinutes),
                Expires = DateTime.Now.AddMinutes(JwtSettings.ExpirationMinutes),
                SigningCredentials = signingCredentials,
                EncryptingCredentials = encryptingCredentials,
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(descriptor);
            var jwt = tokenHandler.WriteToken(securityToken);

            return jwt;
        }

        private async Task<IEnumerable<Claim>> GetClaims(User user)
        {

            var list = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),                
                new Claim("UserGroup",user.UserGroup.ToString())
            };

            return await Task.FromResult(list);
        }
    }
}
