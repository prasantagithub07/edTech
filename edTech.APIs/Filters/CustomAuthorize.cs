using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Text;

namespace edTech.APIs.Filters
{
    public class CustomAuthorize : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string authorization = context.HttpContext.Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(authorization))
            {
                context.Result = new UnauthorizedResult();
            }
            else if(authorization.StartsWith("Bearer "))
            {
                string token = authorization.Substring("Bearer ".Length).Trim();
                if(!string.IsNullOrEmpty(token))
                {
                    //TO DO:
                    try
                    {
                        string jwtKey = "DNTSecretKeyForJWT_Token";
                        string jwtIssuer = "edtechapi.com";
                        string jwtAudience = "edtechui.com";

                        SecurityKey key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtKey));
                        TokenValidationParameters validationParameters =
                            new TokenValidationParameters
                            {
                                ValidateIssuer = true,
                                ValidIssuer = jwtIssuer,
                                ValidAudiences = new[] { jwtAudience },
                                ValidateIssuerSigningKey = true,
                                IssuerSigningKey = key
                            };

                        SecurityToken validateToken;
                        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                        var user = handler.ValidateToken(token, validationParameters, out validateToken);

                        if (!user.Identity.IsAuthenticated)
                        {
                            context.Result = new UnauthorizedResult();
                        }

                    }
                    catch(SecurityTokenValidationException ex)
                    {
                        context.Result = new UnauthorizedResult();
                    }
                    catch (Exception ex)
                    {
                        context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
                    }
                }
            }
        }
    }
}
