using WaterPoint.Api.Common;
using WaterPoint.Core.Domain.QueryParameters.QuoteTasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Payloads.QuoteTasks;
using WaterPoint.Core.Domain.Requests.QuoteTasks;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.QuoteTasks
{
    public class UpdateQuoteTaskProcessor :
        BaseUpdateProcessor<UpdateQuoteTaskRequest, UpdateQuoteTaskPayload, UpdateQuoteTask, GetQuoteTask, QuoteTask>
    {
        public UpdateQuoteTaskProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IPatchEntityAdapter adapter,
            IQuery<GetQuoteTask> getQuery,
            IQueryRunner<GetQuoteTask, QuoteTask> getRunner,
            ICommand<UpdateQuoteTask> updateCommand,
            ICommandExecutor<UpdateQuoteTask> updateExecutor)
            : base(dapperUnitOfWork, adapter, getQuery, getRunner, updateCommand, updateExecutor)
        {
        }

        public override GetQuoteTask BuildGetParameter(UpdateQuoteTaskRequest input)
        {
            return new GetQuoteTask
            {
                OrganizationId = input.OrganizationId,
                QuoteId = input.QuoteId,
                Id = input.Id
            };
        }
    }
}
