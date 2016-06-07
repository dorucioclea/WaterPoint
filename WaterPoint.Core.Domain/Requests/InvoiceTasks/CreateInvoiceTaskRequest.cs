using WaterPoint.Core.Domain.Payloads.InvoiceTasks;

namespace WaterPoint.Core.Domain.Requests.InvoiceTasks
{
    public class CreateInvoiceTaskRequest : ICreateRequest<CreateInvoiceTaskPayload>
    {
        public CreateInvoiceTaskPayload Payload { get; set; }
    }
}
