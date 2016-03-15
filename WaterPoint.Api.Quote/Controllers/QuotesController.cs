using System.Web.Http;
using System.Web.Http.OData;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Quotes;
using WaterPoint.Core.Domain.Payloads.Quotes;
using WaterPoint.Core.Domain.Requests.Quotes;

namespace WaterPoint.Api.Quote.Controllers
{
    [RoutePrefix("organizations/{organizationId:int}")]
    public class QuotesController : BaseOrgnizationContextController
    {
        private readonly IWriteRequestProcessor<CreateQuoteRequest> _createProcessor;
        private readonly IPagedProcessor<ListQuotesRequest, QuoteBasicContract> _listQuoteRequestProcessor;
        private readonly IRequestProcessor<GetQuoteRequest, QuoteContract> _getQuoteByIdRequestProcessor;
        private readonly IWriteRequestProcessor<UpdateQuoteRequest> _updateQuoteRequestProcessor;

        public QuotesController(
            IWriteRequestProcessor<CreateQuoteRequest> createProcessor,
            IPagedProcessor<ListQuotesRequest, QuoteBasicContract> listQuoteRequestProcessor,
            IRequestProcessor<GetQuoteRequest, QuoteContract> getQuoteByIdRequestProcessor,
            IWriteRequestProcessor<UpdateQuoteRequest> updateQuoteRequestProcessor)
        {
            _createProcessor = createProcessor;
            _listQuoteRequestProcessor = listQuoteRequestProcessor;
            _getQuoteByIdRequestProcessor = getQuoteByIdRequestProcessor;
            _updateQuoteRequestProcessor = updateQuoteRequestProcessor;
        }

        [Route("customers/{customerId:int}/quotes")]
        public IHttpActionResult Post(
            [FromUri]CreateQuoteRequest request,
            [FromBody]CreateQuotePayload payload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestWithErrors();
            }

            request.Payload = payload;

            var result = _createProcessor.Process(request);

            return Ok(result);
        }

        [Route("")]
        public IHttpActionResult Get([FromUri]ListQuotesRequest request)
        {
            var result = _listQuoteRequestProcessor.Process(request);

            return Ok(result);
        }

        [Route("{id:int}")]
        public IHttpActionResult Get([FromUri]GetQuoteRequest request)
        {
            var result = _getQuoteByIdRequestProcessor.Process(request);

            return Ok(result);
        }

        [Route("{id:int}")]
        public IHttpActionResult Put(
            [FromUri]UpdateQuoteRequest request,
            [FromBody]Delta<UpdateQuotePayload> input)
        {
            request.Payload = input;

            var job = _updateQuoteRequestProcessor.Process(request);

            return Ok(job);
        }
    }
}
