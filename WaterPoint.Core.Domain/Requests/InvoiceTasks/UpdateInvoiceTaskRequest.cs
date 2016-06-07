using System.Web.Http.OData;
using WaterPoint.Core.Domain.Payloads.InvoiceTasks;

namespace WaterPoint.Core.Domain.Requests.InvoiceTasks
{
    public class UpdateInvoiceTaskRequest : IUpdateRequest<UpdateInvoiceTaskPayload>
    {
        public Delta<UpdateInvoiceTaskPayload> Payload { get; set; }
    }
}
