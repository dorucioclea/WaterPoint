using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Invoices;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Commands.Invoices
{
    public class CreateInvoiceCommand : ICommand<CreateInvoice>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public CreateInvoiceCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(CreateInvoice parameter)
        {
            var builder = _sqlBuilderFactory.Create<CreateSqlBuilder<Invoice>>();

            builder.Analyze<CreateInvoice>();
            builder.AddValueParameters(parameter);

            var sql = builder.GetSql();

            Query = sql;
            Parameters = builder.Parameters;
        }
        public string Query { get; private set; }
        public object Parameters { get; private set; }
        public bool IsStoredProcedure => false;
    }
}
