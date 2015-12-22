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
    [Authorize]
    [RoutePrefix(RouteDefinitions.TaskDefinition.Prefix)]
    public class TaskDefinitionsController : BaseOrgnizationContextController
    {
        private readonly IRequestProcessor<ListPaginatedWithOrgIdRequest, PaginatedResult<IEnumerable<TaskDefinitionContract>>> _listTaskDefinitionequestProcessor;
        private readonly IRequestProcessor<CreateTaskDefinitionRequest, TaskDefinitionContract> _createTaskDefinitionRequest;
        private readonly IRequestProcessor<UpdateTaskDefinitionRequest, TaskDefinitionContract> _updateRequestProcessor;
        private readonly IRequestProcessor<GetTaskDefinitionByIdRequest, TaskDefinitionContract> _getTaskDefinitionByIdProcessor;


        public TaskDefinitionsController(
            IRequestProcessor<ListPaginatedWithOrgIdRequest, PaginatedResult<IEnumerable<TaskDefinitionContract>>> listTaskDefinitionequestProcessor,
            IRequestProcessor<CreateTaskDefinitionRequest, TaskDefinitionContract> createTaskDefinitionRequest,
            IRequestProcessor<UpdateTaskDefinitionRequest, TaskDefinitionContract> updateRequestProcessor,
            IRequestProcessor<GetTaskDefinitionByIdRequest, TaskDefinitionContract> getTaskDefinitionByIdProcessor
            )
        {
            _listTaskDefinitionequestProcessor = listTaskDefinitionequestProcessor;
            _createTaskDefinitionRequest = createTaskDefinitionRequest;
            _updateRequestProcessor = updateRequestProcessor;
            _getTaskDefinitionByIdProcessor = getTaskDefinitionByIdProcessor;
        }

        [Route("")]
        public IHttpActionResult Get(
            [FromUri]OrgIdParameter parameter,
            [FromUri]PaginationParamter pagination)
        {
            var request = new ListPaginatedWithOrgIdRequest
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
            [FromUri]OrgIdParameter parameter,
            [FromBody]WriteTaskDefinitionPayload taskDefinitionPayload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = _createTaskDefinitionRequest.Process(
                new CreateTaskDefinitionRequest
                {
                    OrganizationId = parameter,
                    Payload = taskDefinitionPayload,
                    OrganizationUserId = OrganizationUser.Id
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
                    Parameter = parameter,
                    Payload = input,
                    OrganizationUserId = OrganizationUser.Id
                });

            return Ok(taskDefinition);
        }
    }

}
