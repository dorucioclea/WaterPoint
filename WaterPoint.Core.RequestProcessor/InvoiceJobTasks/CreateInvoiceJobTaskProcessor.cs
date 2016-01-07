using Utility;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.InvoiceJobTasks;
using WaterPoint.Core.Domain.Requests.InvoiceJobTasks;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.InvoiceJobTasks
{
    public class CreateInvoiceJobTaskProcessor
        : BaseCreateProcessor<CreateInvoiceJobTaskRequest, CreateInvoiceJobTask>
    {
        public CreateInvoiceJobTaskProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<CreateInvoiceJobTask> command,
            ICommandExecutor<CreateInvoiceJobTask> executor)
            : base(dapperUnitOfWork, command, executor)
        {
        }

        public override CreateInvoiceJobTask BuildParameter(CreateInvoiceJobTaskRequest input)
        {
            var createInvoiceJobTask = input.MapTo(new CreateInvoiceJobTask());

            input.Payload.MapTo(createInvoiceJobTask);

            return createInvoiceJobTask;
        }
    }
}
