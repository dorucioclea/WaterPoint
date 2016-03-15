using WaterPoint.Core.Domain.QueryParameters.InvoiceCostItems;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Commands.InvoiceCostItems
{
    public class UpdateInvoiceCostItemCommand : ICommand<UpdateInvoiceCostItem>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public UpdateInvoiceCostItemCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(UpdateInvoiceCostItem parameter)
        {
            var builder = _sqlBuilderFactory.Create<UpdateSqlBuilder<InvoiceCostItem>>();

            builder.Analyze(parameter);
            builder.AddValueParameters(parameter);

            builder.AddConditions<InvoiceCostItem>(i => i.Id == parameter.Id);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = builder.Parameters;
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
        public bool IsStoredProcedure => false;
    }
}
