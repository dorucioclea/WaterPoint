using System.ComponentModel.DataAnnotations;

namespace WaterPoint.Core.Domain.Requests.CostItems
{
    public class BulkDeleteCostItemsRequest : IRequest
    {
        public int OrganizationId { get; set; }
        //TODO: add validation regex
        [Required]
        public string CostItems { get; set; }
    }
}
