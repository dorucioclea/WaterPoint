using System.Web.Http;
using WaterPoint.Api.Common;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Contracts.JobTimesheet;
using WaterPoint.Core.Domain.Payloads.JobTimesheet;
using WaterPoint.Core.Domain.RequestParameters;
using WaterPoint.Core.Domain.Requests.JobTimesheet;

namespace WaterPoint.Api.Job.Controllers
{
    [Authorize]
    [RoutePrefix(RouteDefinitions.Jobs.JobTimesheetPrefix)]
    public class JobTimesheetController : BaseOrgnizationContextController
    {
        private readonly IRequestProcessor<CreateJobTimesheetRequest, CommandResultContract> _createRequestProcessor;
        private readonly IRequestProcessor<ListJobTimesheetRequest, SimplePaginatedResult<JobTimesheetListContract>> _listoRequestProcessor;
        private readonly IRequestProcessor<GetJobTimesheetRequest, JobTimesheetContract> _getRequestProcessor;

        public JobTimesheetController(
            IRequestProcessor<CreateJobTimesheetRequest, CommandResultContract> createRequestProcessor,
            IRequestProcessor<ListJobTimesheetRequest, SimplePaginatedResult<JobTimesheetListContract>> listoRequestProcessor,
            IRequestProcessor<GetJobTimesheetRequest, JobTimesheetContract> getRequestProcessor)
        {
            _createRequestProcessor = createRequestProcessor;
            _listoRequestProcessor = listoRequestProcessor;
            _getRequestProcessor = getRequestProcessor;
        }

        [Route("")]
        public IHttpActionResult Get(
            [FromUri]OrgIdJobIdIdRp parameter,
            [FromUri]PaginationRp pagination)
        {
            var result = _listoRequestProcessor.Process(new ListJobTimesheetRequest
            {
                Parameter = parameter,
                Pagination = pagination
            });

            return Ok(result);
        }

        [Route("")]
        public IHttpActionResult Post(
            [FromUri]OrgIdJobIdIdRp parameter,
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

        [Route("{id:int}")]
        public IHttpActionResult Get([FromUri]OrgIdJobIdIdRp parameter)
        {
            var result = _getRequestProcessor.Process(new GetJobTimesheetRequest
            {
                Parameter = parameter
            });

            return Ok(result);
        }
    }
}
