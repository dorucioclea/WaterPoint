namespace WaterPoint.Core.Domain.Requests.InvoiceJobTasks
{
    public class GetInvoiceJobTaskRequest : IRequest
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int InvoiceId { get; set; }
    }
}
