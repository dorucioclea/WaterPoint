using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Credentials;
using WaterPoint.Core.Domain.QueryParameters.OrganizationUsers;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Commands.OrganizationUsers
{
    public class CreateOrganizationUserCommand : ICommand<CreateOrganizationUser>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public CreateOrganizationUserCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(CreateOrganizationUser input)
        {
            var builder = _sqlBuilderFactory.Create<CreateSqlBuilder<OrganizationUser>>();

            builder.Analyze<CreateOrganizationUser>();
            builder.AddValueParameters(input);

            var sql = builder.GetSql();

            Query = sql;
            Parameters = builder.Parameters;
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
        public bool IsStoredProcedure => false;
    }
}
