using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.InvoiceJobCostItems;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.InvoiceJobCostItems;
using WaterPoint.Core.Domain.Requests.InvoiceJobCostItems;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.InvoiceJobCostItems
{
    public class GetInvoiceJobCostItemProcessor :
        BaseDapperUowRequestProcess,
        IRequestProcessor<GetInvoiceJobCostItemRequest, InvoiceJobCostItemContract>
    {
        private readonly IQuery<GetInvoiceJobCostItem> _query;
        private readonly IQueryRunner<GetInvoiceJobCostItem, InvoiceJobCostItem> _runner;

        public GetInvoiceJobCostItemProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<GetInvoiceJobCostItem> query,
            IQueryRunner<GetInvoiceJobCostItem, InvoiceJobCostItem> runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public InvoiceJobCostItemContract Process(GetInvoiceJobCostItemRequest input)
        {
            _query.BuildQuery(new GetInvoiceJobCostItem
            {
                Id = input.Id,
                OrganizationId = input.OrganizationId,
                InvoiceId = input.InvoiceId
            });

            using (DapperUnitOfWork.Begin())
            {
                var quotecostitem = _runner.Run(_query);

                var result = InvoiceJobCostItemMapper.Map(quotecostitem);

                return result;
            }
        }
    }
}
