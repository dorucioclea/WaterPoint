using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Payloads.QuoteCostItems;
using WaterPoint.Core.Domain.Requests.QuoteCostItems;

namespace WaterPoint.Api.Quote.Controllers
{
    [RoutePrefix("organizations/{organizationId:int}")]
    public class CostsController : BaseOrgnizationContextController
    {
        private readonly IWriteRequestProcessor<CreateQuoteCostItemRequest> _createProcessor;

        public CostsController(
            IWriteRequestProcessor<CreateQuoteCostItemRequest> createProcessor)
        {
            _createProcessor = createProcessor;
        }

        [Route("customers/{customerId:int}/quotes/{quoteId:int}/costs")]
        public IHttpActionResult Post(
            [FromUri]CreateQuoteCostItemRequest request,
            [FromBody]CreateQuoteCostItemPayload payload)
        {
            request.Payload = payload;

            var result = _createProcessor.Process(request);

            return Ok(result);
        }
    }
}
