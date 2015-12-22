using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using WaterPoint.Api.Common;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.JobTasks;
using WaterPoint.Core.Domain.Dtos;
using WaterPoint.Core.Domain.Dtos.Payloads.JobTasks;
using WaterPoint.Core.Domain.Dtos.Requests.JobTasks;
using WaterPoint.Core.Domain.Dtos.Requests.Shared;

namespace WaterPoint.Api.JobTask.Controllers
{
    [RoutePrefix(RouteDefinitions.JobTask.Prefix)]
    public class JobTasksController : BaseOrgnizationContextController
    {
        private readonly IRequestProcessor<CreateJobTaskRequest, JobTaskContract> _createJobTaskRequest;
        //private readonly IRequestProcessor<ListPaginatedWithOrgIdRequest, PaginatedResult<IEnumerable<JobTaskContract>>> _listJobTaskequestProcessor;
        //private readonly IRequestProcessor<UpdateJobTaskRequest, JobTaskContract> _updateRequestProcessor;
        private readonly IRequestProcessor<GetJobTaskByIdRequest, JobTaskContract> _getJobTaskByIdProcessor;


        public JobTasksController(
            IRequestProcessor<CreateJobTaskRequest, JobTaskContract> createJobTaskRequest,
            //IRequestProcessor<ListPaginatedWithOrgIdRequest, PaginatedResult<IEnumerable<JobTaskContract>>> listJobTaskequestProcessor,
            //IRequestProcessor<UpdateJobTaskRequest, JobTaskContract> updateRequestProcessor,
            IRequestProcessor<GetJobTaskByIdRequest, JobTaskContract> getJobTaskByIdProcessor)
        {
            //_listJobTaskequestProcessor = listJobTaskequestProcessor;
            _createJobTaskRequest = createJobTaskRequest;
            //_updateRequestProcessor = updateRequestProcessor;
            _getJobTaskByIdProcessor = getJobTaskByIdProcessor;
        }

        //[Route("")]
        //public IHttpActionResult Get(
        //    [FromUri]OrgIdParameter parameter,
        //    [FromUri]PaginationParamter pagination)
        //{
        //    //validation
        //    var request = new ListPaginatedWithOrgIdRequest
        //    {
        //        OrganizationIdParameter = parameter,
        //        PaginationParamter = pagination
        //    };

        //    var result = _listJobTaskequestProcessor.Process(request);

        //    return Ok(result);
        //}

        [Route("{id:int}")]
        public IHttpActionResult Get([FromUri]OrganizationEntityParameter parameter)
        {
            var result = _getJobTaskByIdProcessor.Process(
                new GetJobTaskByIdRequest
                {
                    Id = parameter.Id
                });

            return Ok(result);
        }

        [Route("")]
        public IHttpActionResult Post(
            [FromUri]OrgIdParameter parameter,
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

        //[Route("{id:int}")]
        //public IHttpActionResult Put(
        //    [FromUri] OrganizationEntityParameter parameter,
        //    [FromBody] Delta<WriteJobTaskPayload> input)
        //{
        //    var jobTask = _updateRequestProcessor.Process(
        //        new UpdateJobTaskRequest
        //        {
        //            OrganizationEntityParameter = parameter,
        //            UpdateJobTaskPayload = input,
        //            OrganizationUserId = OrganizationUser.Id
        //        });

        //    return Ok(jobTask);
        //}
    }

}
