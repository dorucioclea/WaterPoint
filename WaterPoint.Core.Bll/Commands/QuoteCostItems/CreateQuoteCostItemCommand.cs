using System;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.QuoteCostItems;
using WaterPoint.Core.Domain.QueryParameters.Quotes;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.QuoteCostItems;

namespace WaterPoint.Core.Bll.Commands.QuoteCostItems
{
    public class CreateQuoteCostItemCommand : ICommand<CreateQuoteCostItem>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public CreateQuoteCostItemCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(CreateQuoteCostItem input)
        {
            var builder = _sqlBuilderFactory.Create<CreateSqlBuilder<QuoteCostItem>>();

            builder.Analyze<CreateQuoteCostItem>();
            builder.AddValueParameters(input);

            var sql = builder.GetSql();

            Query = sql;
            Parameters = builder.Parameters;
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
