using System.Web.Http;
using System.Web.Http.OData;
using WaterPoint.Api.Common;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Contracts.JobCostItems;
using WaterPoint.Core.Domain.Payloads.JobCostItems;
using WaterPoint.Core.Domain.Payloads.Jobs;
using WaterPoint.Core.Domain.Requests.Jobs;

namespace WaterPoint.Api.Job.Controllers
{
    [Authorize]
    [RoutePrefix("organizations/{organizationId:int}/jobs/{jobId:int}/staff")]
    public class StaffController : BaseOrgnizationContextController
    {
        private readonly IWriteRequestProcessor<CreateJobStaffRequest> _createJobStaffProcessor;

        public StaffController(
            IWriteRequestProcessor<CreateJobStaffRequest> createJobStaffProcessor)
        {
            _createJobStaffProcessor = createJobStaffProcessor;
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
    }
}
