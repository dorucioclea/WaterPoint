using System;
using System.Collections.Generic;
using System.Linq;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.UserPrivileges;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.UserPrivileges;
using WaterPoint.Core.Domain.Requests.UserPrivileges;
using WaterPoint.Data.Entity.Pocos.Privileges;

namespace WaterPoint.Core.RequestProcessor.UserPrivileges
{
    public class ListUserPrivilegesProcessor : IListProcessor<ListUserPrivilegesRequest, UserPrivilegeContract>
    {
        private readonly IQuery<ListUserPrivileges> _query;
        private readonly IQueryListRunner<ListUserPrivileges, OrganizationUserPrivilegePoco> _runner;

        public ListUserPrivilegesProcessor(
            IQuery<ListUserPrivileges> query,
            IQueryListRunner<ListUserPrivileges, OrganizationUserPrivilegePoco> runner)
        {
            _query = query;
            _runner = runner;
        }

        public IEnumerable<UserPrivilegeContract> Process(ListUserPrivilegesRequest input)
        {
            _query.BuildQuery(new ListUserPrivileges { OrgnizationUserIds = input.OrganizationUserIds });

            var result = _runner.Run(_query);

            var userPrivilegeContracts = result.GroupBy(i => i.OrganizationUserId)
                .Select(i => new UserPrivilegeContract
                {
                    OrgUserId = i.Key,
                    Privileges = i.Select(p => new PrivilegeContract { Id = p.PrivilegeId })
                });

            return userPrivilegeContracts;
        }
    }
}
