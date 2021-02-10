using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RentNow.Application.Interfaces;
using RentNow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JsonWebToken = RentNow.Application.DTOs.Jwt.JsonWebToken;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace RentNow.Application.Jwt
{
    public class JwtGenerator : ITokenGenerator
    {
        //    "Issuer": "https://localhost:5001",
        //"Secret": "VeryHyperMegaSuperSecretKey",
        //"ExpirationInMinutes": 60,
        //"Audience": [
        //  "https://localhost:5001"
        //]
        private const string Issuer = "https://localhost:5001";
        private const string Secret = "VeryHyperMegaSuperSecretKey";
        private const int ExpirationInMinutes = 60;
        private const string Audience = "https://localhost:5001";
        private readonly JwtSettings jwtSettings;
        public JwtGenerator(IOptionsSnapshot<JwtSettings> jwtSettings)
        {
            this.jwtSettings = jwtSettings.Value;
        }

        public Task<JsonWebToken> GenerateToken(User user)
        {
            var listClaims = GetUserClaims(user);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(Convert.ToDouble(ExpirationInMinutes));

            var token = new JwtSecurityToken(
                    issuer: Issuer,
                    claims: listClaims,
                    expires: expires,
                    signingCredentials: creds
                );

            return Task.FromResult(new JsonWebToken
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                ExpiresIn = expires
            });

        }

        private List<Claim> GetUserClaims(User user)
        {
            return new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Key.ToString()),
                new Claim(ClaimTypes.Name, user.Credentials.Login),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim(JwtRegisteredClaimNames.Aud, Audience),
            };
        }
    }
}
