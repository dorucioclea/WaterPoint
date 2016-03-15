using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Domain.Contracts.InvoiceCostItems;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.InvoiceCostItems;
using WaterPoint.Core.Domain.Requests.InvoiceCostItems;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos.InvoiceCostItems;

namespace WaterPoint.Core.RequestProcessor.InvoiceCostItems
{
    public class ListInvoiceCostItemsProcessor :
        SimplePagedProcessor<ListInvoiceCostItemsRequest, ListInvoiceCostItems, InvoiceCostItemBasicPoco, BasicInvoiceCostItemContract>
    {
        public ListInvoiceCostItemsProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<ListInvoiceCostItems, InvoiceCostItemBasicPoco> listQuery,
            IPagedQueryRunner listQueryRunner)
            : base(dapperUnitOfWork, listQuery, listQueryRunner)
        {
        }

        public override BasicInvoiceCostItemContract Map(InvoiceCostItemBasicPoco source)
        {
            return InvoiceCostItemMapper.Map(source);
        }
    }
}
