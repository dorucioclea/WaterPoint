using System.Web.Http.OData;
using WaterPoint.Core.Domain.Payloads.InvoiceJobTasks;

namespace WaterPoint.Core.Domain.Requests.InvoiceJobTasks
{
    public class UpdateInvoiceJobTaskRequest : IUpdateRequest<UpdateInvoiceJobTaskPayload>
    {
        public Delta<UpdateInvoiceJobTaskPayload> Payload { get; set; }
    }
}
