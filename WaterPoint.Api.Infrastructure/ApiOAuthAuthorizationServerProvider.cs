using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Credentials;
using WaterPoint.Core.Domain.Contracts.OAuthClients;
using WaterPoint.Core.Domain.Requests.Credentials;
using WaterPoint.Core.Domain.Requests.OAuthClients;
using WaterPoint.Data.Entity.Pocos.Views;

namespace WaterPoint.Api.Infrastructure
{
    public class ApiOAuthAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IRequestProcessor<GetOAuthClientRequest, OAuthClientContract> _oauthRequestProcessor;
        private readonly IRequestCollectionProcessor<ListValidateCredentialsRequest, ValidCredentialContract> _credentialRequestProcessor;

        public ApiOAuthAuthorizationServerProvider(
            IRequestProcessor<GetOAuthClientRequest, OAuthClientContract> oauthRequestProcessor,
            IRequestCollectionProcessor<ListValidateCredentialsRequest, ValidCredentialContract> credentialRequestProcessor)
        {
            _oauthRequestProcessor = oauthRequestProcessor;
            _credentialRequestProcessor = credentialRequestProcessor;
        }

        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            context.Validated();

            return Task.FromResult(0);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            if (string.IsNullOrWhiteSpace(context.UserName) || string.IsNullOrWhiteSpace(context.Password))
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");

                return;
            }

            var credentials = _credentialRequestProcessor.Process(new ListValidateCredentialsRequest
            {
                Username = context.UserName,
                Password = context.Password
            }).ToArray();

            if (credentials.Length == 0)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");

                return;
            }

            var oauthIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Email, context.UserName),
                new Claim(ClaimTypes.Sid, context.UserName),
                new Claim(ClaimTypes.PrimaryGroupSid, JsonConvert.SerializeObject(credentials)),
            }, OAuthDefaults.AuthenticationType);

            var cookiesIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Email, context.UserName),
                new Claim(ClaimTypes.Sid, context.UserName),
                new Claim(ClaimTypes.PrimaryGroupSid, JsonConvert.SerializeObject(credentials)),
            }, CookieAuthenticationDefaults.AuthenticationType);

            var properties = CreateProperties(context.UserName);

            var ticket = new AuthenticationTicket(oauthIdentity, properties);

            context.Validated(ticket);

            context.Request.Context.Authentication.SignIn(cookiesIdentity);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId, clientSecret;

            if (!context.TryGetFormCredentials(out clientId, out clientSecret))
            {
                context.Rejected();
            }

            var oauthClient = _oauthRequestProcessor.Process(new GetOAuthClientRequest
            {
                ClientSecret = clientSecret,
                ClientId = clientId,
                IsInternal = true
            });

            // Resource owner password credentials does not provide a client ID.
            if (oauthClient == null)
            {
                context.Rejected();
            }
            else
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            var publicClientId = "publicclientid";

            if (context.ClientId == publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }

            return Task.FromResult<object>(null);
        }

        public static AuthenticationProperties CreateProperties(string userName)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName }
            };
            return new AuthenticationProperties(data);
        }
    }
}
