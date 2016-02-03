using System.Collections.Generic;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using Ninject.Modules;
using WaterPoint.Api.Infrastructure;
using WaterPoint.Core.Bll.Commands.OrganizationUsers;
using WaterPoint.Core.Bll.Commands.UserPrivileges;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.Bll.Queries.Credentials;
using WaterPoint.Core.Bll.Queries.OAuthClients;
using WaterPoint.Core.Bll.Queries.Staff;
using WaterPoint.Core.Bll.Queries.UserPrivileges;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Domain.QueryParameters.Credentials;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Credentials;
using WaterPoint.Core.Domain.Contracts.OAuthClients;
using WaterPoint.Core.Domain.Contracts.Staff;
using WaterPoint.Core.Domain.Contracts.UserPrivileges;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.OrganizationUsers;
using WaterPoint.Core.Domain.QueryParameters.Staff;
using WaterPoint.Core.Domain.QueryParameters.UserPrivileges;
using WaterPoint.Core.Domain.Requests.Credentials;
using WaterPoint.Core.Domain.Requests.OAuthClients;
using WaterPoint.Core.Domain.Requests.OrganizationUsers;
using WaterPoint.Core.Domain.Requests.Staff;
using WaterPoint.Core.Domain.Requests.UserPrivileges;
using WaterPoint.Core.RequestProcessor.Credentials;
using WaterPoint.Core.RequestProcessor.OAuthClients;
using WaterPoint.Core.RequestProcessor.OrganizationUsers;
using WaterPoint.Core.RequestProcessor.Staff;
using WaterPoint.Core.RequestProcessor.UserPrivileges;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.Privileges;
using WaterPoint.Data.Entity.Pocos.Staff;
using WaterPoint.Data.Entity.Pocos.Views;

namespace WaterPoint.Api.DependencyInjection
{
    public class AuthorizationApiModule : NinjectModule
    {
        public override void Load()
        {
            BindRequestProcessors();
            BindQueries();
            BindProviders();
            BindCommands();
        }

        private void BindQueries()
        {
            Bind<IQuery<ListCredentials, ValidCredential>>().To<ListValidateCredentialsQuery>();

            Bind<IQuery<GetAuthClient, OAuthClient>>().To<GetOAuthClientQuery>();

            Bind<IQuery<ListUserPrivileges, OrganizationUserPrivilegePoco>>().To<ListUserPrivilegesQuery>();

            Bind<IQuery<ListStaff, BasicStaffPoco>>().To<ListStaffQuery>();

            Bind<IQuery<GetStaff, Data.Entity.DataEntities.Staff>>().To<GetStaffQuery>();
        }

        public void BindCommands()
        {
            Bind<ICommand<EnterOrganization>>().To<EnterOrganizationCommand>();
            Bind<ICommand<AdjustUserPrivilege>>().To<AdjustUserPrivilegeCommand>();
        }

        private void BindRequestProcessors()
        {
            Bind<IRequestProcessor<GetOAuthClientRequest, OAuthClientContract>>()
                .To<GetOAuthClientProcessor>();

            Bind<IListProcessor<ListValidateCredentialsRequest, ValidCredentialContract>>()
                .To<ListValidateCredentialProcessor>();

            Bind<IListProcessor<ListUserPrivilegesRequest, UserPrivilegeContract>>()
                .To<ListUserPrivilegesProcessor>();

            Bind<IWriteRequestProcessor<EnterOrganizationRequest>>()
                .To<EnterOrganizationProcessor>();

            Bind<IWriteRequestProcessor<AdjustUserPrivilegeRequest>>()
                .To<AdjustUserPrivilegeProcessor>();

            Bind<IListProcessor<ListStaffRequest, BasicStaffContract>>()
               .To<ListStaffProcessor>();

            Bind<IRequestProcessor<GetStaffRequest, StaffContract>>()
                .To<GetStaffProcessor>();
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
