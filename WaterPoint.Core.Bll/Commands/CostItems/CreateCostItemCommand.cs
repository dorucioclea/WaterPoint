using WaterPoint.Core.Domain.QueryParameters.CostItems;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Commands.CostItems
{
    public class CreateCostItemCommand : ICommand<CreateCostItem>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public CreateCostItemCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(CreateCostItem input)
        {
            var builder = _sqlBuilderFactory.Create<CreateSqlBuilder<CostItem>>();

            builder.Analyze<CreateCostItem>();
            builder.AddValueParameters(input);

            var sql = builder.GetSql();

            Query = sql;
            Parameters = builder.Parameters;
        }
        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
