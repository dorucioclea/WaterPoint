using System;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.InvoiceCostItems;
using WaterPoint.Core.Domain.QueryParameters.Invoices;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.InvoiceCostItems;

namespace WaterPoint.Core.Bll.Commands.InvoiceCostItems
{
    public class CreateInvoiceCostItemCommand : ICommand<CreateInvoiceCostItem>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public CreateInvoiceCostItemCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(CreateInvoiceCostItem input)
        {
            var builder = _sqlBuilderFactory.Create<CreateSqlBuilder<InvoiceCostItem>>();

            builder.Analyze<CreateInvoiceCostItem>();
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
