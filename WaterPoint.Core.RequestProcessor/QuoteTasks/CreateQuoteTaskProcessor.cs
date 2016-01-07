using Utility;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.QuoteTasks;
using WaterPoint.Core.Domain.Requests.QuoteTasks;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.QuoteTasks
{
    public class CreateQuoteTaskProcessor : BaseCreateProcessor<CreateQuoteTaskRequest, CreateQuoteTask>
    {
        public CreateQuoteTaskProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<CreateQuoteTask> command,
            ICommandExecutor<CreateQuoteTask> executor)
            : base(dapperUnitOfWork, command, executor)
        {
        }

        public override CreateQuoteTask BuildParameter(CreateQuoteTaskRequest input)
        {
            var createQuoteTask = input.MapTo(new CreateQuoteTask());

            input.Payload.MapTo(createQuoteTask);

            return createQuoteTask;
        }
    }
}
