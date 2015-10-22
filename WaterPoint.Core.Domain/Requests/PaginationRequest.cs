using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Core.Domain.Requests
{
    public class PaginationRequest : IUriQueryRequest
    {
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
        public string Sort { get; set; }
        public bool? Desc { get; set; }
    }
}
