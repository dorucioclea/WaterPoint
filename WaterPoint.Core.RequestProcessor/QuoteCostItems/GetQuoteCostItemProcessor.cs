using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.QuoteCostItems;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.QuoteCostItems;
using WaterPoint.Core.Domain.Requests.QuoteCostItems;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.QuoteCostItems
{
    public class GetQuoteCostItemProcessor :
        BaseDapperUowRequestProcess,
        IRequestProcessor<GetQuoteCostItemRequest, QuoteCostItemContract>
    {
        private readonly IQuery<GetQuoteCostItem, QuoteCostItem> _query;
        private readonly IQueryRunner _runner;

        public GetQuoteCostItemProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<GetQuoteCostItem, QuoteCostItem> query,
            IQueryRunner runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public QuoteCostItemContract Process(GetQuoteCostItemRequest input)
        {
            _query.BuildQuery(new GetQuoteCostItem
            {
                Id = input.Id,
                OrganizationId = input.OrganizationId,
                QuoteId = input.QuoteId
            });

            using (DapperUnitOfWork.Begin())
            {
                var quotecostitem = _runner.Run(_query);

                var result = QuoteCostItemMapper.Map(quotecostitem);

                return result;
            }
        }
    }
}
