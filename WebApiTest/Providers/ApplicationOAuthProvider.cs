using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTest.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext c)
        {
            c.Validated();

            return Task.FromResult<object>(null);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            context.AdditionalResponseParameters.Add("Cliente", "Leonardo");

            return Task.FromResult<object>(null);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext c)
        {
            if (c.UserName == "leonardo" && c.Password == "123123")
            {
                Claim claim1 = new Claim(ClaimTypes.Name, c.UserName);
                Claim[] claims = new Claim[] { claim1 };
                ClaimsIdentity claimsIdentity =
                    new ClaimsIdentity(
                       claims, OAuthDefaults.AuthenticationType);
                c.Validated(claimsIdentity);
            }

            return Task.FromResult<object>(null);
        }
    }
}
