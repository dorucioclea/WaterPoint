using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Core.Domain.Requests
{
    public class PaginationRequest : IRequest
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
