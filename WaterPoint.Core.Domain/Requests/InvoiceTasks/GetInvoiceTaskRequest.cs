namespace WaterPoint.Core.Domain.Requests.InvoiceTasks
{
    public class GetInvoiceTaskRequest : IRequest
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int InvoiceId { get; set; }
    }
}
