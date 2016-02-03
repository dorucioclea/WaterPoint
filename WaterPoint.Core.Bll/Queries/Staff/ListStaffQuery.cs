using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Staff;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.Staff;

namespace WaterPoint.Core.Bll.Queries.Staff
{
    public class ListStaffQuery : IQuery<ListStaff, BasicStaffPoco>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        private readonly string _sqlTemplate = $@"
                SELECT
                    {SqlPatterns.Columns}
                    ,[TotalCount]
                FROM
                    {SqlPatterns.FromTable}
                    CROSS APPLY(
                        SELECT COUNT(*) TotalCount
                        FROM
                            {SqlPatterns.FromTable}
                        WHERE
                            {SqlPatterns.Where}
                    )[Count]
                WHERE
                   {SqlPatterns.Where}
                ORDER BY 1 DESC";

        public ListStaffQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(ListStaff parameter)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            var isWorking = parameter.IsWorking ?? true;

            builder.AddTemplate(_sqlTemplate);
            builder.AddColumns<BasicStaffPoco>();
            builder.AddConditions<BasicStaffPoco>(
                i => i.OrganizationId == parameter.OrganizationId
                && i.IsWorking == isWorking
                && i.IsDeleted == false);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = new
            {
                organizationId = parameter.OrganizationId,
                offset = parameter.Offset,
                pageSize = parameter.PageSize,
                isworking = isWorking,
                isdeleted = parameter.IsDeleted
            };
        }

        public bool IsStoredProcedure => false;
        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
