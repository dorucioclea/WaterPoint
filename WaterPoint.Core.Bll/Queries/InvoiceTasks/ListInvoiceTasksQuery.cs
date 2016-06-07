using WaterPoint.Core.Domain.QueryParameters.InvoiceTasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.Pocos.InvoiceTasks;

namespace WaterPoint.Core.Bll.Queries.InvoiceTasks
{
    public class ListInvoiceTasksQuery : IQuery<ListInvoiceTasks, InvoiceTaskBasicPoco>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        private readonly string _sqlTemplate = $@"
                SELECT
                    {SqlPatterns.Columns}
                    ,[TotalCount]
                FROM
                    {SqlPatterns.FromTable}
                    JOIN dbo.[Invoice] q ON qt.InvoiceId = q.Id
                    CROSS APPLY(
                        SELECT COUNT(*) TotalCount
                        FROM
                            {SqlPatterns.FromTable}
                        WHERE
                            {SqlPatterns.Where}
                            AND (q.OrganizationId = @organizationid)
                    )[Count]
                WHERE
                    {SqlPatterns.Where}
                    AND (q.OrganizationId = @organizationid)
                ORDER BY 1 DESC
                OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY  ";

        public ListInvoiceTasksQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(ListInvoiceTasks parameter)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);
            builder.AddColumns<InvoiceTaskBasicPoco>();
            builder.AddConditions<InvoiceTaskBasicPoco>(i => i.InvoiceId == parameter.InvoiceId);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = new
            {
                organizationId = parameter.OrganizationId,
                offset = parameter.Offset,
                pageSize = parameter.PageSize
            };
        }

        public bool IsStoredProcedure => false;
        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
