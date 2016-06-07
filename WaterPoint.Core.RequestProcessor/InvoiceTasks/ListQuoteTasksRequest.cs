using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Domain.Contracts.InvoiceTasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.InvoiceTasks;
using WaterPoint.Core.Domain.Requests.InvoiceTasks;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos.InvoiceTasks;

namespace WaterPoint.Core.RequestProcessor.InvoiceTasks
{
    public class ListInvoiceTasksProcessor :
        SimplePagedProcessor<ListInvoiceTasksRequest, ListInvoiceTasks, InvoiceTaskBasicPoco, InvoiceTaskBasicContract>
    {
        public ListInvoiceTasksProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<ListInvoiceTasks, InvoiceTaskBasicPoco> listQuery,
            IPagedQueryRunner listRunner)
            : base(dapperUnitOfWork, listQuery, listRunner)
        {
        }

        public override InvoiceTaskBasicContract Map(InvoiceTaskBasicPoco source)
        {
            return InvoiceTaskMapper.Map(source);
        }
    }
}
