using Ninject.Modules;
using WaterPoint.Core.Bll.Commands.Credentials;
using WaterPoint.Core.Bll.Commands.OrganizationUsers;
using WaterPoint.Core.Bll.Commands.Staff;
using WaterPoint.Core.Bll.Commands.UserPrivileges;
using WaterPoint.Core.Bll.Queries.Staff;
using WaterPoint.Core.Bll.Queries.UserPrivileges;
using WaterPoint.Core.Domain.QueryParameters.Credentials;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Staff;
using WaterPoint.Core.Domain.Contracts.UserPrivileges;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.OrganizationUsers;
using WaterPoint.Core.Domain.QueryParameters.Staff;
using WaterPoint.Core.Domain.QueryParameters.UserPrivileges;
using WaterPoint.Core.Domain.Requests.Staff;
using WaterPoint.Core.Domain.Requests.UserPrivileges;
using WaterPoint.Core.RequestProcessor.Staff;
using WaterPoint.Core.RequestProcessor.UserPrivileges;
using WaterPoint.Data.Entity.Pocos.Privileges;
using WaterPoint.Data.Entity.Pocos.Staff;
using OrgStaff = WaterPoint.Data.Entity.DataEntities.Staff;


namespace WaterPoint.Api.DependencyInjection
{
    public class AdminApiModule : NinjectModule
    {
        public override void Load()
        {
            BindRequestProcessors();
            BindQueries();
            BindCommands();
        }

        private void BindQueries()
        {
            Bind<IQuery<ListStaff, BasicStaffPoco>>().To<ListStaffQuery>();
            Bind<IQuery<GetStaff, OrgStaff>>().To<GetStaffQuery>();
            Bind<IQuery<GetStaffByLoginEmail, OrgStaff>>().To<GetStaffByLoginEmailQuery>();
            Bind<IQuery<ListUserPrivileges, OrganizationUserPrivilegePoco>>().To<ListUserPrivilegesQuery>();
        }

        public void BindCommands()
        {
            Bind<ICommand<CreateStaff>>().To<CreateStaffCommand>();
            Bind<ICommand<UndeleteStaffByLoginEmail>>().To<UndeleteStaffQueryByLoginEmailCommand>();
            Bind<ICommand<CreateCredential>>().To<CreateCredentialCommand>();
            Bind<ICommand<CreateOrganizationUser>>().To<CreateOrganizationUserCommand>();
            Bind<ICommand<AdjustUserPrivilege>>().To<AdjustUserPrivilegeCommand>();
        }

        private void BindRequestProcessors()
        {
            Bind<ISimplePagedProcessor<ListStaffRequest, BasicStaffContract>>()
               .To<ListStaffProcessor>();

            Bind<IRequestProcessor<GetStaffRequest, StaffContract>>()
                .To<GetStaffProcessor>();

            Bind<IWriteRequestProcessor<CreateStaffRequest>>().To<CreateStaffProcessor>();

            Bind<IWriteRequestProcessor<AdjustUserPrivilegeRequest>>()
                .To<AdjustUserPrivilegeProcessor>();

            Bind<IListProcessor<ListUserPrivilegesRequest, UserPrivilegeContract>>()
                .To<ListUserPrivilegesProcessor>();
        }
    }
}
