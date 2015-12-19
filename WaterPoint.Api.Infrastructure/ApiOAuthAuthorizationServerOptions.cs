using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using Ninject;

namespace WaterPoint.Api.Infrastructure
{
    public class ApiOAuthAuthorizationServerOptions : OAuthAuthorizationServerOptions
    {

        private readonly IAuthenticationTokenProvider _refreshTokenProvider;
        private readonly IAuthenticationTokenProvider _accessTokenProvider;
        private readonly IOAuthAuthorizationServerProvider _interalOAuthAuthorizationServerProvider;

        public ApiOAuthAuthorizationServerOptions(
            [Named("RefreshTokenProvider")]
            IAuthenticationTokenProvider refreshTokenProvider,
            [Named("AccessTokenProvider")]
            IAuthenticationTokenProvider accessTokenProvider,
            IOAuthAuthorizationServerProvider interalOAuthAuthorizationServerProvider)
        {
            _refreshTokenProvider = refreshTokenProvider;
            _accessTokenProvider = accessTokenProvider;
            _interalOAuthAuthorizationServerProvider = interalOAuthAuthorizationServerProvider;
        }

        public OAuthAuthorizationServerOptions GetOptions()
        {

            var internalApplicationOAuthOptions = new OAuthAuthorizationServerOptions
            {
                //AccessTokenProvider = _accessTokenProvider,
                //RefreshTokenProvider = _refreshTokenProvider,
                TokenEndpointPath = new PathString("/token"),
                Provider = _interalOAuthAuthorizationServerProvider,
                AuthorizeEndpointPath = new PathString("/authorize"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(30),
                // In production mode set AllowInsecureHttp = false
                AllowInsecureHttp = true
            };

            return internalApplicationOAuthOptions;
        }
    }
}
