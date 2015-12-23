using WaterPoint.Core.Domain.QueryParameters.CostItems;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Commands.CostItems
{
    public class UpdateCostItemCommand : ICommand<UpdateCostItem>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public UpdateCostItemCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(UpdateCostItem parameter)
        {
            var builder = _sqlBuilderFactory.Create<UpdateSqlBuilder<CostItem>>();

            builder.Analyze(parameter);
            builder.AddValueParameters(parameter);

            builder.AddConditions<CostItem>(i => i.OrganizationId == parameter.OrganizationId && i.Id == parameter.Id);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = builder.Parameters;
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
