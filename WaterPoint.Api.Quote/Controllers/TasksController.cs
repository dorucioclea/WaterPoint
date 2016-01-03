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
using WaterPoint.Core.Domain.Payloads.Quotes;
using WaterPoint.Core.Domain.RequestParameters;
using WaterPoint.Core.Domain.Requests.Quotes;

namespace WaterPoint.Api.Quote.Controllers
{
    [RoutePrefix("organizations/{organizationId:int}")]
    public class TasksController : BaseOrgnizationContextController
    {
        private readonly IWriteRequestProcessor<CreateQuoteTaskRequest> _createProcessor;

        public TasksController(
            IWriteRequestProcessor<CreateQuoteTaskRequest> createProcessor
            //,
            //ISimplePaginatedProcessor<ListQuoteTasksRequest, QuoteListContract> listQuoteTasksProcessor
            )

        {
            _createProcessor = createProcessor;
        }

        [Route("customers/{customerId:int}/quotes/{quoteId:int}/tasks")]
        public IHttpActionResult Post(
            [FromUri]CreateQuoteTaskRequest request,
            [FromBody]CreateQuoteTaskPayload payload)
        {
            if (!ModelState.IsValid)
                return BadRequestWithErrors(ModelState);

            request.Payload = payload;

            _createProcessor.Process(request);

            return Ok(request);
        }
    }
}
