using WaterPoint.Core.Domain.QueryParameters.CostItems;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Queries.CostItems
{
    public class GetCostItemQuery : IQuery<GetCostItem>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        private readonly string _sqlTemplate = $@"
                SELECT
                    {SqlPatterns.Columns}
                FROM
                    {SqlPatterns.FromTable}
                WHERE
                   {SqlPatterns.Where}";

        public GetCostItemQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(GetCostItem parameter)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);
            builder.AddColumns<CostItem>();
            builder.AddConditions<CostItem>(i => i.OrganizationId == parameter.OrganizationId && i.Id == parameter.CostItemId);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = new
            {
                organizationId = parameter.OrganizationId,
                costItemId = parameter.CostItemId
            };
        }

        public bool IsStoredProcedure => false;
        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
