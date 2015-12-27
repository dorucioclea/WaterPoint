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
using WaterPoint.Core.Domain.Contracts.JobTimesheet;
using WaterPoint.Core.Domain.Payloads.Customers;
using WaterPoint.Core.Domain.RequestParameters;
using WaterPoint.Core.Domain.Requests.JobTimesheet;

namespace WaterPoint.Api.Customer.Controllers
{
    [Authorize]
    [RoutePrefix(RouteDefinitions.Customers.JobTimesheetPrefix)]
    public class JobTimesheetController : BaseOrgnizationContextController
    {
        private readonly IRequestProcessor<CreateJobTimesheetRequest, CommandResultContract> _createRequestProcessor;

        public JobTimesheetController(
            IRequestProcessor<CreateJobTimesheetRequest, CommandResultContract> createRequestProcessor)
        {
            _createRequestProcessor = createRequestProcessor;
        }

        [Route("")]
        public IHttpActionResult Post(
            [FromUri]OrgIdCusIdJobId parameter,
            [FromBody]WriteJobTimesheetPayload payload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //TODO: validator
            //TODO: staff privilege (admin can create timesheet for others, but others can only create for themselves)

            var result = _createRequestProcessor.Process(new CreateJobTimesheetRequest
            {
                Parameter = parameter,
                Payload = payload
            });

            return Ok(result);
        }
    }
}
