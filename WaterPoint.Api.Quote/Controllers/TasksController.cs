using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WaterPoint.Api.Common;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Contracts.QuoteTasks;
using WaterPoint.Core.Domain.Payloads.Quotes;
using WaterPoint.Core.Domain.RequestParameters;
using WaterPoint.Core.Domain.Requests.Quotes;
using WaterPoint.Core.Domain.Requests.QuoteTasks;

namespace WaterPoint.Api.Quote.Controllers
{
    [RoutePrefix("organizations/{organizationId:int}")]
    public class TasksController : BaseOrgnizationContextController
    {
        private readonly IWriteRequestProcessor<CreateQuoteTaskRequest> _createProcessor;
        private readonly ISimplePagedProcessor<ListQuoteTasksRequest, QuoteTaskBasicContract> _listQuoteTasksProcessor;

        public TasksController(
            IWriteRequestProcessor<CreateQuoteTaskRequest> createProcessor,
            ISimplePagedProcessor<ListQuoteTasksRequest, QuoteTaskBasicContract> listQuoteTasksProcessor)

        {
            _createProcessor = createProcessor;
            _listQuoteTasksProcessor = listQuoteTasksProcessor;
        }

        [Route("customers/{customerId:int}/quotes/{quoteId:int}/tasks")]
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

        [Route("customers/{customerId:int}/quotes/{quoteId:int}/tasks")]
        public IHttpActionResult Get([FromUri]ListQuoteTasksRequest request)
        {
            var result = _listQuoteTasksProcessor.Process(request);

            return Ok(result);
        }
    }
}
