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
    [RoutePrefix(RouteDefinitions.Organizations.Prefix)]
    public class QuotesController : BaseOrgnizationContextController
    {
        private readonly IRequestProcessor<CreateQuoteRequest, CommandResultContract> _createProcessor;

        public QuotesController(
            IRequestProcessor<CreateQuoteRequest, CommandResultContract> createProcessor)
        {
            _createProcessor = createProcessor;
        }

        [Route("customers/{customerId:int}/quotes")]
        public IHttpActionResult Post(
            [FromUri]OrgIdCusIdRp parameter,
            [FromBody]CreateQuotePayload payload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestWithErrors(ModelState);
            }

            var result = _createProcessor.Process(new CreateQuoteRequest
            {
                Payload = payload,
                Parameter = parameter
            });

            return Ok(result);
        }
    }
}
