using System.Collections.Generic;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using Ninject.Modules;
using WaterPoint.Api.Infrastructure;
using WaterPoint.Core.Bll.Queries.Credentials;
using WaterPoint.Core.Bll.Queries.OAuthClients;
using WaterPoint.Core.Bll.QueryParameters.Credentials;
using WaterPoint.Core.Bll.QueryRunners.Credentials;
using WaterPoint.Core.Bll.QueryRunners.OAuthClients;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.OAuthClients;
using WaterPoint.Core.Domain.Dtos.Requests.Credentials;
using WaterPoint.Core.Domain.Dtos.Requests.OAuthClients;
using WaterPoint.Core.RequestProcessor.Credentials;
using WaterPoint.Core.RequestProcessor.OAuthClients;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.Views;

namespace WaterPoint.Api.DependencyInjection
{
    public class AuthorizationApiModule : NinjectModule
    {
        public override void Load()
        {
            BindRequestProcessors();
            BindQueries();
            BindQueryRunners();
            BindProviders();
            //BindCommands();
            //BindCommandExecutors();
        }

        private void BindQueries()
        {
            Bind<IQuery<ListCredentialsQueryParameter>>().To<ListValidateCredentialsQuery>();

            Bind<IQuery<GetAuthClientQueryParameter>>().To<GetOAuthClientQuery>();
        }

        public void BindQueryRunners()
        {
            Bind<IQueryRunner<ListCredentialsQueryParameter, IEnumerable<ValidCredential>>>()
                .To<ListValidateCredentialsRunner>();

            Bind<IQueryRunner<GetAuthClientQueryParameter, OAuthClient>>()
                .To<GetOAuthClientQueryRunner>();
        }
        private void BindRequestProcessors()
        {
            Bind<IRequestProcessor<GetOAuthClientRequest, OAuthClientContract>>()
                .To<GetOAuthClientRequestProcessor>();

            Bind<IRequestProcessor<ListValidateCredentialsRequest, IEnumerable<ValidCredential>>>()
                .To<ListValidateCredentialRequestProcessor>();
        }

        public void BindProviders()
        {
            Bind<IOAuthAuthorizationServerProvider>().To<ApiOAuthAuthorizationServerProvider>()
                .WhenInjectedExactlyInto<ApiOAuthAuthorizationServerOptions>();

            Bind<IAuthenticationTokenProvider>().To<RefreshTokenProvider>()
                .WhenInjectedExactlyInto<ApiOAuthAuthorizationServerOptions>()
                .Named("RefreshTokenProvider");

            Bind<IAuthenticationTokenProvider>().To<AccessTokenProvider>()
                .WhenInjectedExactlyInto<ApiOAuthAuthorizationServerOptions>()
                .Named("AccessTokenProvider");
        }
    }
}
