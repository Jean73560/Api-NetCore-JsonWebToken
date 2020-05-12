using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using JeanPierre.Models;
using Microsoft.IdentityModel.Tokens;

namespace JeanPierre.WebApi.Authentication
{
    public class JwtProvider : ITokenProvider
    {
        private RsaSecurityKey _Key;
        private string _algoritm;
        private string _issuer;
        private string _audience;

        public JwtProvider(string issuer, string audience, string keyName)
        {
            var parameters = new CspParameters()
            {
                KeyContainerName = keyName,
                Flags = CspProviderFlags.UseMachineKeyStore
            };
            //var provider = new RSACryptoServiceProvider(2048, parameters);
            //_Key = new RsaSecurityKey(provider);
            _algoritm = SecurityAlgorithms.RsaSha256Signature;
            _issuer = issuer;
            _audience = audience;
        }

        public JwtSecurityTokenHandler SecurityToken { get; private set; }

        public string CreateToken(User user, DateTime expiry)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var identity = new ClaimsIdentity(new List<Claim>()
            {
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role,user.Roles),
                new Claim(ClaimTypes.PrimarySid, user.Id.ToString())
            },"Custom");

            SecurityToken token = tokenHandler.CreateJwtSecurityToken(new SecurityTokenDescriptor
            {
                Audience = _audience,
                Issuer = _issuer,
                SigningCredentials = new SigningCredentials(_Key, _algoritm),
                Expires = expiry.ToUniversalTime(),
                Subject = identity
            });
            return tokenHandler.WriteToken(token);
        }

        public TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters
            {
                IssuerSigningKey = _Key,
                ValidAudience = _audience,
                ValidIssuer = _issuer,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromSeconds(0)
            };
        }
    }
}
