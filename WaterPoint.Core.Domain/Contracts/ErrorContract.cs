using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Core.Domain.Contracts
{
    public class ErrorContract
    {
        public string Message { get; set; }
        public IEnumerable<ErrorDetailContract> Errors { get; set; }
    }

    public class ErrorDetailContract
    {
        public string DetailLink { get; set; }
        public string Message { get; set; }
    }
}
