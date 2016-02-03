using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Domain.Contracts.InvoiceJobTasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.InvoiceJobTasks;
using WaterPoint.Core.Domain.Requests.InvoiceJobTasks;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos.InvoiceJobTasks;

namespace WaterPoint.Core.RequestProcessor.InvoiceJobTasks
{
    public class ListInvoiceJobTasksProcessor :
        SimplePagedProcessor<ListInvoiceJobTasksRequest, ListInvoiceJobTasks, InvoiceJobTaskBasicPoco, InvoiceJobTaskBasicContract>
    {
        public ListInvoiceJobTasksProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<ListInvoiceJobTasks, InvoiceJobTaskBasicPoco> listQuery,
            IPagedQueryRunner listRunner)
            : base(dapperUnitOfWork, listQuery, listRunner)
        {
        }

        public override InvoiceJobTaskBasicContract Map(InvoiceJobTaskBasicPoco source)
        {
            return InvoiceJobTaskMapper.Map(source);
        }
    }
}
