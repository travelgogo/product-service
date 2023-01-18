using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Threading;

namespace GoGo.Product.Function.Helpers
{
    public class SecurityHelper
    {
        public static async Task<ClaimsPrincipal> ValidateTokenAsync(AuthenticationHeaderValue value)
        {
            if(value?.Scheme != JwtBearerDefaults.AuthenticationScheme)
                return null;
            
            //var config = await _configurationManager.GetConfigurationAsync(CancellationToken.None);
            var issuer = Environment.GetEnvironmentVariable("Authentication__Authority");
            var validationParameter = new TokenValidationParameters()
            {
                RequireSignedTokens = true,
                ValidIssuer = issuer,
                // ValidAudience = "product_data",
                ValidateAudience = false,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                //IssuerSigningKeys = config.SigningKeys
            };

            ClaimsPrincipal result = null;
            var tries = 0;

            while (result == null && tries <= 1)
            {
                try
                {
                    var handler = new JwtSecurityTokenHandler();
                    result = handler.ValidateToken(value.Parameter, validationParameter, out var token);
                }
                catch (SecurityTokenSignatureKeyNotFoundException)
                {
                    // This exception is thrown if the signature key of the JWT could not be found.
                    // This could be the case when the issuer changed its signing keys, so we trigger a
                    // refresh and retry validation.
                    //_configurationManager.RequestRefresh();
                    tries++;
                }
                catch
                {
                    break;
                }
            }

            return await Task.FromResult(result);
        }
    }
}