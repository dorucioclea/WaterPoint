using System.Collections.Generic;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using Ninject.Modules;
using WaterPoint.Api.Infrastructure;
using WaterPoint.Core.Bll.Queries.Credentials;
using WaterPoint.Core.Bll.Queries.OAuthClients;
using WaterPoint.Core.Bll.Queries.Privileges;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Domain.QueryParameters.Credentials;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Credentials;
using WaterPoint.Core.Domain.Contracts.OAuthClients;
using WaterPoint.Core.Domain.Contracts.Privileges;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Priviledges;
using WaterPoint.Core.Domain.Requests.Credentials;
using WaterPoint.Core.Domain.Requests.OAuthClients;
using WaterPoint.Core.Domain.Requests.Priviledges;
using WaterPoint.Core.RequestProcessor.Credentials;
using WaterPoint.Core.RequestProcessor.OAuthClients;
using WaterPoint.Core.RequestProcessor.Privileges;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.Priviledges;
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
            Bind<IQuery<ListCredentials>>().To<ListValidateCredentialsQuery>();

            Bind<IQuery<GetAuthClient>>().To<GetOAuthClientQuery>();

            Bind<IQuery<ListUserPrivileges>>().To<ListUserPrivilegesQuery>();
        }

        public void BindQueryRunners()
        {
            Bind<IQueryListRunner<ListCredentials, ValidCredential>>()
                .To<QueryListRunner<ListCredentials, ValidCredential>>();

            Bind<IQueryRunner<GetAuthClient, OAuthClient>>()
                .To<QueryRunner<GetAuthClient, OAuthClient>>();

            Bind<IQueryListRunner<ListUserPrivileges, OrganizationUserPrivilegePoco>>()
                .To<QueryListRunner<ListUserPrivileges, OrganizationUserPrivilegePoco>>();
        }
        private void BindRequestProcessors()
        {
            Bind<IRequestProcessor<GetOAuthClientRequest, OAuthClientContract>>()
                .To<GetOAuthClientProcessor>();

            Bind<IRequestListProcessor<ListValidateCredentialsRequest, ValidCredentialContract>>()
                .To<ListValidateCredentialProcessor>();

            Bind<IRequestListProcessor<ListUserPrivilegesRequest, UserPrivilegeContract>>()
                .To<ListUserPrivilegesProcessor>();
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
