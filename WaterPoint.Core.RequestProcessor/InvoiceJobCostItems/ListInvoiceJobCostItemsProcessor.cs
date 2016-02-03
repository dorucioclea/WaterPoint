using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Domain.Contracts.InvoiceJobCostItems;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.InvoiceJobCostItems;
using WaterPoint.Core.Domain.Requests.InvoiceJobCostItems;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos.InvoiceJobCostItems;

namespace WaterPoint.Core.RequestProcessor.InvoiceJobCostItems
{
    public class ListInvoiceJobCostItemsProcessor :
        SimplePagedProcessor<ListInvoiceJobCostItemsRequest, ListInvoiceJobCostItems, InvoiceJobCostItemBasicPoco, InvoiceJobCostItemBasicContract>
    {
        public ListInvoiceJobCostItemsProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<ListInvoiceJobCostItems, InvoiceJobCostItemBasicPoco> listQuery,
            IPagedQueryRunner listQueryRunner)
            : base(dapperUnitOfWork, listQuery, listQueryRunner)
        {
        }

        public override InvoiceJobCostItemBasicContract Map(InvoiceJobCostItemBasicPoco source)
        {
            return InvoiceJobCostItemMapper.Map(source);
        }
    }
}
