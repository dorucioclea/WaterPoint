using WaterPoint.Core.Domain.QueryParameters.CostItems;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.CostItems;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Requests.CostItems;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.CostItems
{
    public class GetCostItemProcessor :
        BaseDapperUowRequestProcess,
        IRequestProcessor<GetCostItemRequest, CostItemContract>
    {
        private readonly IQuery<GetCostItem> _query;
        private readonly IQueryRunner _runner;

        public GetCostItemProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<GetCostItem> query,
            IQueryRunner runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public CostItemContract Process(GetCostItemRequest input)
        {
            var parameter = new GetCostItem
            {
                OrganizationId = input.OrganizationId,
                CostItemId = input.Id
            };

            _query.BuildQuery(parameter);

            using (DapperUnitOfWork.Begin())
            {
                var costItem = _runner.Run<GetCostItem, CostItem>(_query);

                var result = CostItemMapper.Map(costItem);

                return result;
            }
        }
    }
}
