using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.InvoiceJobTasks
{
    public class ListInvoiceJobTasks : ISimplePagedQueryParameter
    {
        public int OrganizationId { get; set; }
        public int InvoiceId { get; set; }
        public int Offset { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
