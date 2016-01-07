using System.Web.Http;
using System.Web.Http.OData;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.QuoteTasks;
using WaterPoint.Core.Domain.Payloads.QuoteTasks;
using WaterPoint.Core.Domain.Requests.QuoteTasks;

namespace WaterPoint.Api.Quote.Controllers
{
    [RoutePrefix("organizations/{organizationId:int}")]
    public class TasksController : BaseOrgnizationContextController
    {
        private readonly IWriteRequestProcessor<CreateQuoteTaskRequest> _createProcessor;
        private readonly ISimplePagedProcessor<ListQuoteTasksRequest, QuoteTaskBasicContract> _listProcessor;
        private readonly IRequestProcessor<GetQuoteTaskRequest, QuoteTaskContract> _getProcessor;
        private readonly IWriteRequestProcessor<UpdateQuoteTaskRequest> _updateProcessor;

        public TasksController(
            IWriteRequestProcessor<CreateQuoteTaskRequest> createProcessor,
            ISimplePagedProcessor<ListQuoteTasksRequest, QuoteTaskBasicContract> listProcessor,
            IRequestProcessor<GetQuoteTaskRequest, QuoteTaskContract> getProcessor,
            IWriteRequestProcessor<UpdateQuoteTaskRequest> updateProcessor)
        {
            _createProcessor = createProcessor;
            _listProcessor = listProcessor;
            _getProcessor = getProcessor;
            _updateProcessor = updateProcessor;
        }

        [Route("quotes/{quoteId:int}/tasks")]
        public IHttpActionResult Post(
            [FromUri]CreateQuoteTaskRequest request,
            [FromBody]CreateQuoteTaskPayload payload)
        {
            if (!ModelState.IsValid)
                return BadRequestWithErrors(ModelState);

            request.Payload = payload;

            var result = _createProcessor.Process(request);

            return Ok(result);
        }

        [Route("quotes/{quoteId:int}/tasks")]
        public IHttpActionResult Get([FromUri]ListQuoteTasksRequest request)
        {
            var result = _listProcessor.Process(request);

            return Ok(result);
        }

        [Route("quotes/{quoteId:int}/tasks/{id:int}")]
        public IHttpActionResult Get([FromUri]GetQuoteTaskRequest request)
        {
            var result = _getProcessor.Process(request);

            return Ok(result);
        }


        [Route("quotes/{quoteId:int}/tasks/{id:int}")]
        public IHttpActionResult Put(
            [FromUri]UpdateQuoteTaskRequest request,
            [FromBody]Delta<UpdateQuoteTaskPayload> payload)
        {
            if (!ModelState.IsValid)
                return BadRequestWithErrors(ModelState);

            request.Payload = payload;

            var result = _updateProcessor.Process(request);

            return Ok(result);
        }
    }
}
