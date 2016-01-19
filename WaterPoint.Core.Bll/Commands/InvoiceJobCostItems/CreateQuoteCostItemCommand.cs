using System;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.InvoiceJobCostItems;
using WaterPoint.Core.Domain.QueryParameters.Invoices;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.InvoiceJobCostItems;

namespace WaterPoint.Core.Bll.Commands.InvoiceJobCostItems
{
    public class CreateInvoiceJobCostItemCommand : ICommand<CreateInvoiceJobCostItem>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public CreateInvoiceJobCostItemCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(CreateInvoiceJobCostItem input)
        {
            var builder = _sqlBuilderFactory.Create<CreateSqlBuilder<InvoiceJobCostItem>>();

            builder.Analyze<CreateInvoiceJobCostItem>();
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
