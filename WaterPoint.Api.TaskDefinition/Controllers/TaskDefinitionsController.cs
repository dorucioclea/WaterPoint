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
using WaterPoint.Core.Domain.Contracts.TaskDefinitions;
using WaterPoint.Core.Domain.Dtos;
using WaterPoint.Core.Domain.Dtos.Payloads.TaskDefinitions;
using WaterPoint.Core.Domain.Dtos.Requests.Shared;
using WaterPoint.Core.Domain.Dtos.Requests.TaskDefinitions;

namespace WaterPoint.Api.TaskDefinition.Controllers
{
    [RoutePrefix(RouteDefinitions.TaskDefinition.Prefix)]
    public class TaskDefinitionsController : BaseOrgnizationContextController
    {
        private readonly IRequestProcessor<PaginationWithOrgIdRequest, PaginatedResult<IEnumerable<TaskDefinitionContract>>> _listTaskDefinitionequestProcessor;
        private readonly IRequestProcessor<CreateTaskDefinitionRequest, TaskDefinitionContract> _createTaskDefinitionRequest;
        private readonly IRequestProcessor<UpdateTaskDefinitionRequest, TaskDefinitionContract> _updateRequestProcessor;
        private readonly IRequestProcessor<GetTaskDefinitionByIdRequest, TaskDefinitionContract> _getTaskDefinitionByIdProcessor;


        public TaskDefinitionsController(
            IRequestProcessor<PaginationWithOrgIdRequest, PaginatedResult<IEnumerable<TaskDefinitionContract>>> listTaskDefinitionequestProcessor,
            IRequestProcessor<CreateTaskDefinitionRequest, TaskDefinitionContract> createTaskDefinitionRequest,
            IRequestProcessor<UpdateTaskDefinitionRequest, TaskDefinitionContract> updateRequestProcessor,
            IRequestProcessor<GetTaskDefinitionByIdRequest, TaskDefinitionContract> getTaskDefinitionByIdProcessor)
        {
            _listTaskDefinitionequestProcessor = listTaskDefinitionequestProcessor;
            _createTaskDefinitionRequest = createTaskDefinitionRequest;
            _updateRequestProcessor = updateRequestProcessor;
            _getTaskDefinitionByIdProcessor = getTaskDefinitionByIdProcessor;
        }

        [Route("")]
        public IHttpActionResult Get(
            [FromUri]OrganizationIdParameter parameter,
            [FromUri]PaginationParamter pagination)
        {
            //validation
            var request = new PaginationWithOrgIdRequest
            {
                OrganizationIdParameter = parameter,
                PaginationParamter = pagination
            };

            var result = _listTaskDefinitionequestProcessor.Process(request);

            return Ok(result);
        }

        [Route("{id:int}")]
        public IHttpActionResult Get([FromUri]OrganizationEntityParameter parameter)
        {
            var result = _getTaskDefinitionByIdProcessor.Process(
                new GetTaskDefinitionByIdRequest
                {
                    OrganizationEntityParameter = parameter
                });

            return Ok(result);
        }

        [Route("")]
        public IHttpActionResult Post(
            [FromUri]OrganizationIdParameter parameter,
            [FromBody]WriteTaskDefinitionPayload taskDefinitionPayload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //TODO: add staff id
            var result = _createTaskDefinitionRequest.Process(
                new CreateTaskDefinitionRequest
                {
                    OrganizationIdParameter = parameter,
                    CreateTaskDefinitionPayload = taskDefinitionPayload,
                    StaffId = Staff.Id
                });

            return Ok(result);
        }

        [Route("{id:int}")]
        public IHttpActionResult Put(
            [FromUri] OrganizationEntityParameter parameter,
            [FromBody] Delta<WriteTaskDefinitionPayload> input)
        {
            var taskDefinition = _updateRequestProcessor.Process(
                new UpdateTaskDefinitionRequest
                {
                    OrganizationEntityParameter = parameter,
                    UpdateTaskDefinitionPayload = input,
                    StaffId = Staff.Id
                });

            return Ok(taskDefinition);
        }
    }

}
