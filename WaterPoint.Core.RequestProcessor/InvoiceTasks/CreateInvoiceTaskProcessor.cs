using Utility;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.InvoiceTasks;
using WaterPoint.Core.Domain.Requests.InvoiceTasks;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.InvoiceTasks
{
    public class CreateInvoiceTaskProcessor
        : BaseCreateProcessor<CreateInvoiceTaskRequest, CreateInvoiceTask>
    {
        public CreateInvoiceTaskProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<CreateInvoiceTask> command,
            ICommandExecutor executor)
            : base(dapperUnitOfWork, command, executor)
        {
        }

        public override CreateInvoiceTask BuildParameter(CreateInvoiceTaskRequest input)
        {
            var createInvoiceTask = input.MapTo(new CreateInvoiceTask());

            input.Payload.MapTo(createInvoiceTask);

            return createInvoiceTask;
        }
    }
}
