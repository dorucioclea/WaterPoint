using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Core.Domain.Dtos.Requests.CostItems
{
    public class ListCostItemsRequest
    {
        public OrgIdParameter OrganizationId { get; set; }
        public PaginationParamter Pagination { get; set; }
    }
}
