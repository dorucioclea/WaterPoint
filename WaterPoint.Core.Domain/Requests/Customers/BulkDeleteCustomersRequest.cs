using System.ComponentModel.DataAnnotations;

namespace WaterPoint.Core.Domain.Requests.Customers
{
    public class BulkDeleteCustomersRequest : IRequest
    {
        public int OrganizationId { get; set; }
        //TODO: add validation regex
        [Required]
        public string Customers { get; set; }
    }
}
