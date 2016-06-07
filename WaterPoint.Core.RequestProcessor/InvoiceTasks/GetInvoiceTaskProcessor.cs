using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.InvoiceTasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.InvoiceTasks;
using WaterPoint.Core.Domain.Requests.InvoiceTasks;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.InvoiceTasks
{
    public class GetInvoiceTaskProcessor : BaseDapperUowRequestProcess,
        IRequestProcessor<GetInvoiceTaskRequest, InvoiceTaskContract>
    {
        private readonly IQuery<GetInvoiceTask, InvoiceTask> _query;
        private readonly IQueryRunner _runner;

        public GetInvoiceTaskProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<GetInvoiceTask, InvoiceTask> query,
            IQueryRunner runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public InvoiceTaskContract Process(GetInvoiceTaskRequest input)
        {
            _query.BuildQuery(new GetInvoiceTask
            {
                Id = input.Id,
                OrganizationId = input.OrganizationId,
                InvoiceId = input.InvoiceId
            });

            using (DapperUnitOfWork.Begin())
            {
                var quotetask = _runner.Run(_query);

                var result = InvoiceTaskMapper.Map(quotetask);

                return result;
            }
        }
    }
}
