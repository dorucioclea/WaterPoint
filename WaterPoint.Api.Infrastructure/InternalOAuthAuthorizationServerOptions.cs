using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;

namespace WaterPoint.Api.Infrastructure
{
    public class InternalOAuthAuthorizationServerOptions : OAuthAuthorizationServerOptions
    {
        //private readonly IAuthenticationTokenProvider _tokenProvider;
        private readonly IOAuthAuthorizationServerProvider _interalOAuthAuthorizationServerProvider;

        public InternalOAuthAuthorizationServerOptions(
            //IAuthenticationTokenProvider tokenProvider,
            IOAuthAuthorizationServerProvider interalOAuthAuthorizationServerProvider)
        {
            //_tokenProvider = tokenProvider;
            _interalOAuthAuthorizationServerProvider = interalOAuthAuthorizationServerProvider;
        }

        public OAuthAuthorizationServerOptions GetOptions()
        {

            var internalApplicationOAuthOptions = new OAuthAuthorizationServerOptions
            {
                //AccessTokenProvider = _tokenProvider,
                //RefreshTokenProvider = _tokenProvider,

                TokenEndpointPath = new PathString("/token"),
                Provider = _interalOAuthAuthorizationServerProvider,
                AuthorizeEndpointPath = new PathString("/authorize"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),
                // In production mode set AllowInsecureHttp = false
                AllowInsecureHttp = true
            };

            return internalApplicationOAuthOptions;
        }
    }
}
