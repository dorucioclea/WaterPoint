using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.InvoiceJobTasks;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Commands.InvoiceJobTasks
{
    public class CreateInvoiceJobTaskCommand : ICommand<CreateInvoiceJobTask>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public CreateInvoiceJobTaskCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(CreateInvoiceJobTask input)
        {
            var builder = _sqlBuilderFactory.Create<CreateSqlBuilder<InvoiceJobTask>>();

            builder.Analyze<CreateInvoiceJobTask>();
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
