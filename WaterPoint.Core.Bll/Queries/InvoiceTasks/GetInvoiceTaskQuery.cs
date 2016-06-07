using WaterPoint.Core.Domain.QueryParameters.InvoiceTasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Queries.InvoiceTasks
{
    public class GetInvoiceTaskQuery : IQuery<GetInvoiceTask, InvoiceTask>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        private readonly string _sqlTemplate = $@"
                SELECT
                    {SqlPatterns.Columns}
                FROM
                    {SqlPatterns.FromTable}
                    JOIN dbo.Invoice q ON qt.InvoiceId = q.Id
                WHERE
                   {SqlPatterns.Where}
                    AND (q.OrganizationId = @organizationid) ";

        public GetInvoiceTaskQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(GetInvoiceTask parameter)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);
            builder.AddColumns<InvoiceTask>();
            builder.AddConditions<InvoiceTask>(i => i.Id == parameter.Id && i.InvoiceId == parameter.InvoiceId);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = new
            {
                quoteId = parameter.InvoiceId,
                id = parameter.Id,
                organizationid = parameter.OrganizationId
            };
        }

        public bool IsStoredProcedure => false;
        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
