using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Core.Domain.Requests.Products
{
    public class ListProductsByFlagRequest : IServiceRequest
    {
        public int FlagId { get; set; }
    }
}
