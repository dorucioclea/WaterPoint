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
        private readonly IRequestProcessor<CreateJobTaskRequest, CommandResultContract> _createJobTaskRequest;
        private readonly IRequestProcessor<ListJobTasksRequest, SimplePaginatedResult<JobTaskBasicContract>> _listJobTaskequestProcessor;
        private readonly IRequestProcessor<UpdateJobTaskRequest, CommandResultContract> _updateRequestProcessor;
        private readonly IRequestProcessor<GetJobTaskByIdRequest, JobTaskContract> _getJobTaskByIdProcessor;

        public TasksController(
            IRequestProcessor<CreateJobTaskRequest, CommandResultContract> createJobTaskRequest,
            IRequestProcessor<ListJobTasksRequest, SimplePaginatedResult<JobTaskBasicContract>> listJobTaskequestProcessor,
            IRequestProcessor<UpdateJobTaskRequest, CommandResultContract> updateRequestProcessor,
            IRequestProcessor<GetJobTaskByIdRequest, JobTaskContract> getJobTaskByIdProcessor)
        {
            _listJobTaskequestProcessor = listJobTaskequestProcessor;
            _createJobTaskRequest = createJobTaskRequest;
            _updateRequestProcessor = updateRequestProcessor;
            _getJobTaskByIdProcessor = getJobTaskByIdProcessor;
        }

        [Route("")]
        public IHttpActionResult Get(
            [FromUri]OrgIdJobIdRp parameter,
            [FromUri]PaginationRp pagination)
        {
            //validation
            var request = new ListJobTasksRequest
            {
                Parameter = parameter,
                Pagination = pagination
            };

            var result = _listJobTaskequestProcessor.Process(request);

            return Ok(result);
        }

        [Route("{id:int}")]
        public IHttpActionResult Get([FromUri]OrgEntityJobId parameter)
        {
            var result = _getJobTaskByIdProcessor.Process(
                new GetJobTaskByIdRequest
                {
                    OrganizationId = parameter.OrganizationId,
                    JobId = parameter.JobId,
                    Id = parameter.Id
                });

            return Ok(result);
        }

        [Route("")]
        public IHttpActionResult Post(
            [FromUri]OrgIdJobIdRp parameter,
            [FromBody]CreateJobTaskPayload jobTaskPayload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _createJobTaskRequest.Process(
                new CreateJobTaskRequest
                {
                    Parameter = parameter,
                    Payload = jobTaskPayload,
                    OrganizationUserId = OrganizationUser.Id
                });

            return Ok(result);
        }

        [Route("{id:int}")]
        public IHttpActionResult Put(
            [FromUri]OrgEntityJobId parameter,
            [FromBody]Delta<UpdateJobTaskPayload> input)
        {
            var jobTask = _updateRequestProcessor.Process(
                new UpdateJobTaskRequest
                {
                    Parameter = parameter,
                    Payload = input,
                    OrganizationUserId = OrganizationUser.Id
                });

            return Ok(jobTask);
        }
    }
}
