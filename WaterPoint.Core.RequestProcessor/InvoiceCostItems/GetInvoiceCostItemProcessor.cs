using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.InvoiceCostItems;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.InvoiceCostItems;
using WaterPoint.Core.Domain.Requests.InvoiceCostItems;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.InvoiceCostItems
{
    public class GetInvoiceCostItemProcessor :
        BaseDapperUowRequestProcess,
        IRequestProcessor<GetInvoiceCostItemRequest, InvoiceCostItemContract>
    {
        private readonly IQuery<GetInvoiceCostItem, InvoiceCostItem> _query;
        private readonly IQueryRunner _runner;

        public GetInvoiceCostItemProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<GetInvoiceCostItem, InvoiceCostItem> query,
            IQueryRunner runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public InvoiceCostItemContract Process(GetInvoiceCostItemRequest input)
        {
            _query.BuildQuery(new GetInvoiceCostItem
            {
                Id = input.Id,
                OrganizationId = input.OrganizationId,
                InvoiceId = input.InvoiceId
            });

            using (DapperUnitOfWork.Begin())
            {
                var quotecostitem = _runner.Run(_query);

                var result = InvoiceCostItemMapper.Map(quotecostitem);

                return result;
            }
        }
    }
}
