using System;
using JeanPierre.Models;
using Microsoft.IdentityModel.Tokens;

namespace JeanPierre.WebApi.Authentication
{
    public interface ITokenProvider
    {
        string CreateToken(User user, DateTime expiry);
        TokenValidationParameters GetValidationParameters();
    }
}
