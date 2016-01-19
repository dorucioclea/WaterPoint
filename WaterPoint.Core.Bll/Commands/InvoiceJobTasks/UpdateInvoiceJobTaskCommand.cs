using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.InvoiceJobTasks;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Commands.InvoiceJobTasks
{
    public class UpdateInvoiceJobTaskCommand : ICommand<UpdateInvoiceJobTask>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public UpdateInvoiceJobTaskCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(UpdateInvoiceJobTask parameter)
        {
            var builder = _sqlBuilderFactory.Create<UpdateSqlBuilder<InvoiceJobTask>>();

            builder.Analyze(parameter);

            builder.AddValueParameters(parameter);

            builder.AddConditions<InvoiceJobTask>(i => i.Id == parameter.Id);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = builder.Parameters;
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
        public bool IsStoredProcedure => false;
    }
}
