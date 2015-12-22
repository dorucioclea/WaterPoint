using WaterPoint.Core.Bll.QueryParameters.CostItems;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.CostItems;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Dtos.Requests.CostItems;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.CostItems
{
    public class GetCostItemProcessor :
        BaseDapperUowRequestProcess,
        IRequestProcessor<GetCostItemRequest, CostItemContract>
    {
        private readonly IQuery<GetCostItem> _query;
        private readonly IQueryRunner<GetCostItem, CostItem> _runner;

        public GetCostItemProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<GetCostItem> query,
            IQueryRunner<GetCostItem, CostItem> runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public CostItemContract Process(GetCostItemRequest input)
        {
            var parameter = new GetCostItem
            {
                OrganizationId = input.OrganizationEntityParameter.OrganizationId,
                CostItemId = input.OrganizationEntityParameter.Id
            };

            _query.BuildQuery(parameter);

            using (DapperUnitOfWork.Begin())
            {
                var costItem = _runner.Run(_query);

                var result = CostItemMapper.Map(costItem);

                return result;
            }
        }
    }
}
