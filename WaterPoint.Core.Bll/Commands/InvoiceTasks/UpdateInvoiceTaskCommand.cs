using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.InvoiceTasks;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Commands.InvoiceTasks
{
    public class UpdateInvoiceTaskCommand : ICommand<UpdateInvoiceTask>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public UpdateInvoiceTaskCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(UpdateInvoiceTask parameter)
        {
            var builder = _sqlBuilderFactory.Create<UpdateSqlBuilder<InvoiceTask>>();

            builder.Analyze(parameter);

            builder.AddValueParameters(parameter);

            builder.AddConditions<InvoiceTask>(i => i.Id == parameter.Id);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = builder.Parameters;
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
        public bool IsStoredProcedure => false;
    }
}
