using WaterPoint.Core.Domain.QueryParameters.InvoiceJobTasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Queries.InvoiceJobTasks
{
    public class GetInvoiceJobTaskQuery : IQuery<GetInvoiceJobTask>
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

        public GetInvoiceJobTaskQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(GetInvoiceJobTask parameter)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);
            builder.AddColumns<InvoiceJobTask>();
            builder.AddConditions<InvoiceJobTask>(i => i.Id == parameter.Id && i.InvoiceId == parameter.InvoiceId);

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
