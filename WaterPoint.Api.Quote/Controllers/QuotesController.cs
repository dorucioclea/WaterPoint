using System.Web.Http;
using WaterPoint.Api.Common;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Payloads.Quotes;
using WaterPoint.Core.Domain.RequestParameters;
using WaterPoint.Core.Domain.Requests.Quotes;

namespace WaterPoint.Api.Quote.Controllers
{
    [RoutePrefix("organizations/{organizationId:int}")]
    public class QuotesController : BaseOrgnizationContextController
    {
        private readonly IWriteRequestProcessor<CreateQuoteRequest> _createProcessor;

        public QuotesController(
            IWriteRequestProcessor<CreateQuoteRequest> createProcessor)
        {
            _createProcessor = createProcessor;
        }

        [Route("customers/{customerId:int}/quotes")]
        public IHttpActionResult Post(
            [FromUri]CreateQuoteRequest request,
            [FromBody]CreateQuotePayload payload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestWithErrors(ModelState);
            }

            request.Payload = payload;

            var result = _createProcessor.Process(request);

            return Ok(result);
        }
    }
}
