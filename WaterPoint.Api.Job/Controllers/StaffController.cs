using System.Web.Http;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Staff;
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
        private readonly IListProcessor<ListJobStaffRequest, JobStaffContract> _listJobStaffPoProcessor;

        public StaffController(
            IWriteRequestProcessor<CreateJobStaffRequest> createJobStaffProcessor,
            IWriteRequestProcessor<DeleteJobStaffRequest> deleteRequestProcessor,
            IListProcessor<ListJobStaffRequest, JobStaffContract> listJobStaffPoProcessor)
        {
            _createJobStaffProcessor = createJobStaffProcessor;
            _deleteRequestProcessor = deleteRequestProcessor;
            _listJobStaffPoProcessor = listJobStaffPoProcessor;
        }

        [Route("")]
        public IHttpActionResult Get([FromUri]ListJobStaffRequest request)
        {
            var result = _listJobStaffPoProcessor.Process(request);

            return Ok(result);
        }

        [Route("")]
        public IHttpActionResult Post(
            [FromUri]CreateJobStaffRequest request,
            [FromBody]CreateJobStaffPayload payload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestWithErrors();
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
