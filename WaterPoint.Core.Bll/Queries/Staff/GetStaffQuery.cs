using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Staff;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Queries.Staff
{
    public class GetStaffQuery : IQuery<GetStaff>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        private readonly string _sqlTemplate = $@"
                SELECT
                    {SqlPatterns.Columns}
                FROM
                    {SqlPatterns.FromTable}
                WHERE
                   {SqlPatterns.Where}";

        public GetStaffQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(GetStaff parameter)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);
            builder.AddColumns<Data.Entity.DataEntities.Staff>();
            builder.AddConditions<Data.Entity.DataEntities.Staff>(
                i => i.OrganizationId == parameter.OrganizationId && i.OrganizationUserId == parameter.OrganizationUserId);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = new
            {
                organizationId = parameter.OrganizationId,
                organizationUserId = parameter.OrganizationUserId
            };
        }

        public bool IsStoredProcedure => false;
        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
