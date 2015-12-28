using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.JobCostItems
{
    public class ListJobCostItemsRequest : IRequest
    {
        public OrgIdJobIdRp Parameter { get; set; }
        public PaginationRp Pagination { get; set; }
    }
}
