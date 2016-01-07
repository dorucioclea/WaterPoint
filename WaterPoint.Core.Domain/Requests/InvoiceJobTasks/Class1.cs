using WaterPoint.Core.Domain.Payloads.InvoiceJobTasks;

namespace WaterPoint.Core.Domain.Requests.InvoiceJobTasks
{
    public class CreateInvoiceJobTaskRequest : ICreateRequest<CreateInvoiceJobTaskPayload>
    {
        public CreateInvoiceJobTaskPayload Payload { get; set; }
    }
}
