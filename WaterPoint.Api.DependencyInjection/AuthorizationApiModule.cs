using Microsoft.Owin.Security.OAuth;
using Ninject.Modules;
using WaterPoint.Api.Infrastructure;
using WaterPoint.Core.Bll.Queries.Credentials;
using WaterPoint.Core.Bll.Queries.OAuthClients;
using WaterPoint.Core.Bll.QueryRunners.Credentials;
using WaterPoint.Core.Bll.QueryRunners.OAuthClients;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.OAuthClients;
using WaterPoint.Core.Domain.Dtos.Requests.Credentials;
using WaterPoint.Core.Domain.Dtos.Requests.OAuthClients;
using WaterPoint.Core.RequestProcessor.Credentials;
using WaterPoint.Core.RequestProcessor.OAuthClients;

namespace WaterPoint.Api.DependencyInjection
{
    public class AuthorizationApiModule : NinjectModule
    {
        public override void Load()
        {
            BindRequestProcessors();
            BindQueriesAndCommands();
        }

        private void BindQueriesAndCommands()
        {
            Bind<ValidateCredentialQuery>().ToSelf();
            Bind<ValidateCredentialQueryRunner>().ToSelf();
            Bind<GetOAuthClientQuery>().ToSelf();
            Bind<GetOAuthClientQueryRunner>().ToSelf();


            Bind<IOAuthAuthorizationServerProvider>().To<InternalApplicationOAuthProvider>()
                .WhenInjectedExactlyInto<InternalOAuthAuthorizationServerOptions>();


        }

        private void BindRequestProcessors()
        {
            Bind<IRequestProcessor<GetOAuthClientRequest, OAuthClientContract>>()
                .To<GetOAuthClientRequestProcessor>();

            Bind<IRequestProcessor<ValidateCredentialRequest, bool>>()
                .To<ValidateCredentialRequestProcessor>();
        }
    }
}
