using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain.Payloads.Quotes;
using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.Quotes
{
    public class CreateQuoteRequest : IRequest
    {
        public OrgIdCusIdRp Parameter { get; set; }
        public CreateQuotePayload Payload { get; set; }
    }
}
