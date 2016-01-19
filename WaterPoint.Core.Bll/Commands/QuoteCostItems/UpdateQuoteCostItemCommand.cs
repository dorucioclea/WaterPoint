using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.QuoteCostItems;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Commands.QuoteCostItems
{
    public class UpdateQuoteCostItemCommand : ICommand<UpdateQuoteCostItem>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public UpdateQuoteCostItemCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(UpdateQuoteCostItem parameter)
        {
            var builder = _sqlBuilderFactory.Create<UpdateSqlBuilder<QuoteCostItem>>();

            builder.Analyze(parameter);

            builder.AddValueParameters(parameter);

            builder.AddConditions<QuoteCostItem>(i => i.Id == parameter.Id);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = builder.Parameters;
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
        public bool IsStoredProcedure => false;
    }
}
