using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.InvoiceJobTasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.InvoiceJobTasks;
using WaterPoint.Core.Domain.Requests.InvoiceJobTasks;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.InvoiceJobTasks
{
    public class GetInvoiceJobTaskProcessor : BaseDapperUowRequestProcess,
        IRequestProcessor<GetInvoiceJobTaskRequest, InvoiceJobTaskContract>
    {
        private readonly IQuery<GetInvoiceJobTask> _query;
        private readonly IQueryRunner<GetInvoiceJobTask, InvoiceJobTask> _runner;

        public GetInvoiceJobTaskProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<GetInvoiceJobTask> query,
            IQueryRunner<GetInvoiceJobTask, InvoiceJobTask> runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public InvoiceJobTaskContract Process(GetInvoiceJobTaskRequest input)
        {
            _query.BuildQuery(new GetInvoiceJobTask
            {
                Id = input.Id,
                OrganizationId = input.OrganizationId,
                InvoiceId = input.InvoiceId
            });

            using (DapperUnitOfWork.Begin())
            {
                var quotetask = _runner.Run(_query);

                var result = InvoiceJobTaskMapper.Map(quotetask);

                return result;
            }
        }
    }
}
