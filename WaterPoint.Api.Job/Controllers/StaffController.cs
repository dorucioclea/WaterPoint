using System.Web.Http;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Payloads.Jobs;
using WaterPoint.Core.Domain.QueryParameters.Jobs;
using WaterPoint.Core.Domain.Requests.Jobs;

namespace WaterPoint.Api.Job.Controllers
{
    [Authorize]
    [RoutePrefix("organizations/{organizationId:int}/jobs/{jobId:int}/staff")]
    public class StaffController : BaseOrgnizationContextController
    {
        private readonly IWriteRequestProcessor<CreateJobStaffRequest> _createJobStaffProcessor;
        private readonly IWriteRequestProcessor<DeleteJobStaffRequest> _deleteRequestProcessor;

        public StaffController(
            IWriteRequestProcessor<CreateJobStaffRequest> createJobStaffProcessor,
            IWriteRequestProcessor<DeleteJobStaffRequest> deleteRequestProcessor)
        {
            _createJobStaffProcessor = createJobStaffProcessor;
            _deleteRequestProcessor = deleteRequestProcessor;
        }

        [Route("")]
        public IHttpActionResult Post(
            [FromUri]CreateJobStaffRequest request,
            [FromBody]CreateJobStaffPayload payload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestWithErrors(ModelState);
            }

            request.Payload = payload;

            var result = _createJobStaffProcessor.Process(request);

            return Ok(result);
        }

        [Route("{staffId:int}")]
        public IHttpActionResult Delete([FromUri]DeleteJobStaffRequest request)
        {
            var result = _deleteRequestProcessor.Process(request);

            return Ok(result);
        }
    }
}
