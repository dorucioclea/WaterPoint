using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.InvoiceTasks;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Commands.InvoiceTasks
{
    public class CreateInvoiceTaskCommand : ICommand<CreateInvoiceTask>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public CreateInvoiceTaskCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(CreateInvoiceTask input)
        {
            var builder = _sqlBuilderFactory.Create<CreateSqlBuilder<InvoiceTask>>();

            builder.Analyze<CreateInvoiceTask>();
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
