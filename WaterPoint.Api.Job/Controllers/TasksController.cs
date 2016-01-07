using System.Web.Http;
using System.Web.Http.OData;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Contracts.JobTasks;
using WaterPoint.Core.Domain.Payloads.JobTasks;
using WaterPoint.Core.Domain.RequestParameters;
using WaterPoint.Core.Domain.Requests.JobTasks;

namespace WaterPoint.Api.Job.Controllers
{
    [Authorize]
    [RoutePrefix("organizations/{organizationId:int}/jobs/{jobId:int}/tasks")]
    public class TasksController : BaseOrgnizationContextController
    {
        private readonly IWriteRequestProcessor<CreateJobTaskRequest> _createJobTaskRequest;
        private readonly ISimplePagedProcessor<ListJobTasksRequest, JobTaskBasicContract> _listJobTaskequestProcessor;
        private readonly IWriteRequestProcessor<UpdateJobTaskRequest> _updateRequestProcessor;
        private readonly IRequestProcessor<GetJobTaskByIdRequest, JobTaskContract> _getJobTaskByIdProcessor;

        public TasksController(
            IWriteRequestProcessor<CreateJobTaskRequest> createJobTaskRequest,
            ISimplePagedProcessor<ListJobTasksRequest, JobTaskBasicContract> listJobTaskequestProcessor,
            IWriteRequestProcessor<UpdateJobTaskRequest> updateRequestProcessor,
            IRequestProcessor<GetJobTaskByIdRequest, JobTaskContract> getJobTaskByIdProcessor)
        {
            _listJobTaskequestProcessor = listJobTaskequestProcessor;
            _createJobTaskRequest = createJobTaskRequest;
            _updateRequestProcessor = updateRequestProcessor;
            _getJobTaskByIdProcessor = getJobTaskByIdProcessor;
        }

        [Route("")]
        public IHttpActionResult Get(
            [FromUri]ListJobTasksRequest request)
        {
            var result = _listJobTaskequestProcessor.Process(request);

            return Ok(result);
        }

        [Route("{id:int}")]
        public IHttpActionResult Get([FromUri]GetJobTaskByIdRequest request)
        {
            var result = _getJobTaskByIdProcessor.Process(request);

            return Ok(result);
        }

        [Route("")]
        public IHttpActionResult Post(
            [FromUri]CreateJobTaskRequest request,
            [FromBody]CreateJobTaskPayload jobTaskPayload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestWithErrors(ModelState);
            }

            request.Payload = jobTaskPayload;
            request.OrganizationUserId = OrganizationUser.Id;

            var result = _createJobTaskRequest.Process(request);

            return Ok(result);
        }

        [Route("{id:int}")]
        public IHttpActionResult Put(
            [FromUri]UpdateJobTaskRequest request,
            [FromBody]Delta<UpdateJobTaskPayload> input)
        {
            request.Payload = input;
            request.OrganizationUserId = OrganizationUser.Id;

            var jobTask = _updateRequestProcessor.Process(request);

            return Ok(jobTask);
        }
    }
}
