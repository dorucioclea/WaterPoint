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
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Contracts.TaskDefinitions;

using WaterPoint.Core.Domain.Payloads.TaskDefinitions;
using WaterPoint.Core.Domain.RequestParameters;
using WaterPoint.Core.Domain.Requests.Shared;
using WaterPoint.Core.Domain.Requests.TaskDefinitions;

namespace WaterPoint.Api.TaskDefinition.Controllers
{
    [Authorize]
    [RoutePrefix(RouteDefinitions.TaskDefinition.Prefix)]
    public class TaskDefinitionsController : BaseOrgnizationContextController
    {
        private readonly IRequestProcessor<ListWithOrgIdRequest, PaginatedResult<TaskDefinitionContract>> _listTaskDefinitionequestProcessor;
        private readonly IRequestProcessor<CreateTaskDefinitionRequest, CommandResultContract> _createTaskDefinitionRequest;
        private readonly IRequestProcessor<UpdateTaskDefinitionRequest, CommandResultContract> _updateRequestProcessor;
        private readonly IRequestProcessor<GetTaskDefinitionByIdRequest, TaskDefinitionContract> _getTaskDefinitionByIdProcessor;


        public TaskDefinitionsController(
            IRequestProcessor<ListWithOrgIdRequest, PaginatedResult<TaskDefinitionContract>> listTaskDefinitionequestProcessor,
            IRequestProcessor<CreateTaskDefinitionRequest, CommandResultContract> createTaskDefinitionRequest,
            IRequestProcessor<UpdateTaskDefinitionRequest, CommandResultContract> updateRequestProcessor,
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
            [FromUri]OrgIdRp parameter,
            [FromUri]PaginationRp pagination)
        {
            var request = new ListWithOrgIdRequest
            {
                OrganizationIdParameter = parameter,
                PaginationParamter = pagination
            };

            var result = _listTaskDefinitionequestProcessor.Process(request);

            return Ok(result);
        }

        [Route("{id:int}")]
        public IHttpActionResult Get([FromUri]OrgEntityRp parameter)
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
            [FromUri]OrgIdRp parameter,
            [FromBody]WriteTaskDefinitionPayload taskDefinitionPayload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestWithErrors(ModelState);
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
            [FromUri] OrgEntityRp parameter,
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
