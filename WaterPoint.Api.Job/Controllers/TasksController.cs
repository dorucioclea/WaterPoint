using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData;
using WaterPoint.Api.Common;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.JobTasks;
using WaterPoint.Core.Domain.Dtos;
using WaterPoint.Core.Domain.Dtos.Payloads.JobTasks;
using WaterPoint.Core.Domain.Dtos.RequestParameters;
using WaterPoint.Core.Domain.Dtos.Requests.JobTasks;

namespace WaterPoint.Api.Job.Controllers
{
    [Authorize]
    [RoutePrefix(RouteDefinitions.Jobs.Prefix)]
    public class TasksController : BaseOrgnizationContextController
    {
        private readonly IRequestProcessor<CreateJobTaskRequest, JobTaskContract> _createJobTaskRequest;
        private readonly IRequestProcessor<ListJobTasksRequest, PaginatedResult<JobTaskContract>> _listJobTaskequestProcessor;
        private readonly IRequestProcessor<UpdateJobTaskRequest, JobTaskContract> _updateRequestProcessor;
        private readonly IRequestProcessor<GetJobTaskByIdRequest, JobTaskContract> _getJobTaskByIdProcessor;


        public TasksController(
            IRequestProcessor<CreateJobTaskRequest, JobTaskContract> createJobTaskRequest,
            IRequestProcessor<ListJobTasksRequest, PaginatedResult<JobTaskContract>> listJobTaskequestProcessor,
            IRequestProcessor<UpdateJobTaskRequest, JobTaskContract> updateRequestProcessor,
            IRequestProcessor<GetJobTaskByIdRequest, JobTaskContract> getJobTaskByIdProcessor)
        {
            _listJobTaskequestProcessor = listJobTaskequestProcessor;
            _createJobTaskRequest = createJobTaskRequest;
            _updateRequestProcessor = updateRequestProcessor;
            _getJobTaskByIdProcessor = getJobTaskByIdProcessor;
        }

        [Route(RouteDefinitions.Jobs.Tasks)]
        public IHttpActionResult Get(
            [FromUri]JobIdOrgIdRp parameter,
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

        [Route(RouteDefinitions.Jobs.GetTask)]
        public IHttpActionResult Get([FromUri]OrgEntityRp parameter)
        {
            var result = _getJobTaskByIdProcessor.Process(
                new GetJobTaskByIdRequest
                {
                    Id = parameter.Id
                });

            return Ok(result);
        }

        [Route(RouteDefinitions.Jobs.Tasks)]
        public IHttpActionResult Post(
            [FromUri]OrgIdRp parameter,
            [FromBody]WriteJobTaskPayload jobTaskPayload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _createJobTaskRequest.Process(
                new CreateJobTaskRequest
                {
                    OrganizationId = parameter,
                    Payload = jobTaskPayload,
                    OrganizationUserId = OrganizationUser.Id
                });

            return Ok(result);
        }

        [Route(RouteDefinitions.Jobs.Tasks)]
        public IHttpActionResult Put(
            [FromUri] OrgEntityJobId parameter,
            [FromBody] Delta<WriteJobTaskPayload> input)
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
