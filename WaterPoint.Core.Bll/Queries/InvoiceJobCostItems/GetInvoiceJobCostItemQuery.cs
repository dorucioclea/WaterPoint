using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.InvoiceJobCostItems;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Queries.InvoiceJobCostItems
{
    public class GetInvoiceJobCostItemQuery : IQuery<GetInvoiceJobCostItem>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        private readonly string _sqlTemplate = $@"
                SELECT
                    {SqlPatterns.Columns}
                FROM
                    {SqlPatterns.FromTable}
                    JOIN dbo.Invoice q ON qci.InvoiceId = q.Id
                WHERE
                    {SqlPatterns.Where}
                    AND (q.OrganizationId = @orgnizationid) ";

        public GetInvoiceJobCostItemQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(GetInvoiceJobCostItem parameter)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);
            builder.AddColumns<InvoiceJobCostItem>();
            builder.AddConditions<InvoiceJobCostItem>(i => i.Id == parameter.Id && i.InvoiceId == parameter.InvoiceId);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = new
            {
                id = parameter.Id,
                quoteid = parameter.InvoiceId,
                organizationid = parameter.OrganizationId
            };
        }

        public bool IsStoredProcedure => false;
        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
