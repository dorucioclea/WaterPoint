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
        private readonly IPaginatedProcessor<ListWithOrgIdRequest, TaskDefinitionContract> _listTaskDefinitionequestProcessor;
        private readonly IWriteRequestProcessor<CreateTaskDefinitionRequest> _createTaskDefinitionRequest;
        private readonly IWriteRequestProcessor<UpdateTaskDefinitionRequest> _updateRequestProcessor;
        private readonly IRequestProcessor<GetTaskDefinitionByIdRequest, TaskDefinitionContract> _getTaskDefinitionByIdProcessor;


        public TaskDefinitionsController(
            IPaginatedProcessor<ListWithOrgIdRequest, TaskDefinitionContract> listTaskDefinitionequestProcessor,
            IWriteRequestProcessor<CreateTaskDefinitionRequest> createTaskDefinitionRequest,
            IWriteRequestProcessor<UpdateTaskDefinitionRequest> updateRequestProcessor,
            IRequestProcessor<GetTaskDefinitionByIdRequest, TaskDefinitionContract> getTaskDefinitionByIdProcessor
            )
        {
            _listTaskDefinitionequestProcessor = listTaskDefinitionequestProcessor;
            _createTaskDefinitionRequest = createTaskDefinitionRequest;
            _updateRequestProcessor = updateRequestProcessor;
            _getTaskDefinitionByIdProcessor = getTaskDefinitionByIdProcessor;
        }

        [Route("")]
        public IHttpActionResult Get([FromUri]ListWithOrgIdRequest request)
        {
            var result = _listTaskDefinitionequestProcessor.Process(request);

            return Ok(result);
        }

        [Route("{id:int}")]
        public IHttpActionResult Get([FromUri]GetTaskDefinitionByIdRequest request)
        {
            var result = _getTaskDefinitionByIdProcessor.Process(request);

            return Ok(result);
        }

        [Route("")]
        public IHttpActionResult Post(
            [FromUri]CreateTaskDefinitionRequest request,
            [FromBody]WriteTaskDefinitionPayload taskDefinitionPayload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestWithErrors(ModelState);
            }

            request.Payload = taskDefinitionPayload;
            request.OrganizationUserId = OrganizationUser.Id;

            var result = _createTaskDefinitionRequest.Process(request);

            return Ok(result);
        }

        [Route("{id:int}")]
        public IHttpActionResult Put(
            [FromUri]UpdateTaskDefinitionRequest request,
            [FromBody]Delta<WriteTaskDefinitionPayload> input)
        {
            request.Payload = input;
            request.OrganizationUserId = OrganizationUser.Id;

            var taskDefinition = _updateRequestProcessor.Process(request);

            return Ok(taskDefinition);
        }
    }

}
