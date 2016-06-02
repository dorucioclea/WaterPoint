using System;
using System.Web.Http;
using System.Web.Http.OData;
using WaterPoint.Api.Common;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.TaskDefinitions;

using WaterPoint.Core.Domain.Payloads.TaskDefinitions;
using WaterPoint.Core.Domain.Requests;
using WaterPoint.Core.Domain.Requests.Shared;
using WaterPoint.Core.Domain.Requests.TaskDefinitions;

namespace WaterPoint.Api.TaskDefinition.Controllers
{
    [Authorize]
    [RoutePrefix(RouteDefinitions.TaskDefinition.Prefix)]
    public class TaskDefinitionsController : BaseOrgnizationContextController
    {
        private readonly IPagedProcessor<ListWithOrgIdRequest, TaskDefinitionBasicContract> _listTaskDefinitionequestProcessor;
        private readonly IWriteRequestProcessor<CreateTaskDefinitionRequest> _createTaskDefinitionRequest;
        private readonly IWriteRequestProcessor<UpdateTaskDefinitionRequest> _updateRequestProcessor;
        private readonly IRequestProcessor<GetTaskDefinitionByIdRequest, TaskDefinitionContract> _getTaskDefinitionByIdProcessor;
        private readonly IListProcessor<SearchTermRequest, TaskDefinitionBasicContract> _searchByNameProcessor;


        public TaskDefinitionsController(
            IPagedProcessor<ListWithOrgIdRequest, TaskDefinitionBasicContract> listTaskDefinitionequestProcessor,
            IWriteRequestProcessor<CreateTaskDefinitionRequest> createTaskDefinitionRequest,
            IWriteRequestProcessor<UpdateTaskDefinitionRequest> updateRequestProcessor,
            IRequestProcessor<GetTaskDefinitionByIdRequest, TaskDefinitionContract> getTaskDefinitionByIdProcessor,
            IListProcessor<SearchTermRequest, TaskDefinitionBasicContract> searchByNameProcessor
            )
        {
            _listTaskDefinitionequestProcessor = listTaskDefinitionequestProcessor;
            _createTaskDefinitionRequest = createTaskDefinitionRequest;
            _updateRequestProcessor = updateRequestProcessor;
            _getTaskDefinitionByIdProcessor = getTaskDefinitionByIdProcessor;
            _searchByNameProcessor = searchByNameProcessor;
        }

        [Route("names")]
        public IHttpActionResult Get([FromUri]SearchTermRequest request)
        {
            var searchTerm = SearchTermHelper.ConvertToSearchTerm(request.SearchTerm);

            if (string.IsNullOrWhiteSpace(searchTerm))
                throw new InvalidOperationException("invalid search term");

            request.SearchTerm = searchTerm;

            var result = _searchByNameProcessor.Process(request);

            return Ok(result);
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
                return BadRequestWithErrors();
            }

            request.Payload = taskDefinitionPayload;
            request.OrganizationUserId = Credential.OrganizationUserId;

            var result = _createTaskDefinitionRequest.Process(request);

            return Ok(result);
        }

        [Route("{id:int}")]
        public IHttpActionResult Put(
            [FromUri]UpdateTaskDefinitionRequest request,
            [FromBody]Delta<WriteTaskDefinitionPayload> input)
        {
            request.Payload = input;
            request.OrganizationUserId = Credential.OrganizationUserId;

            var taskDefinition = _updateRequestProcessor.Process(request);

            return Ok(taskDefinition);
        }
    }

}
