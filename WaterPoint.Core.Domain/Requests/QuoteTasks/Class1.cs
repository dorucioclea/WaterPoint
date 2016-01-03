using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.QuoteTasks
{
    public class ListQuoteTasksRequest
    {
        public int QuoteId { get; set; }
        public int OrganizationId { get; set; }
    }
}
