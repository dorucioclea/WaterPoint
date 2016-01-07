using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.InvoiceJobTasks
{
    public class GetInvoiceJobTask : IQueryParameter
    {
        public int OrganizationId { get; set; }
        public int InvoiceId { get; set; }
        public int Id { get; set; }
    }
}
