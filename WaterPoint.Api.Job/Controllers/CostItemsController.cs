using System.Web.Http;
using System.Web.Http.OData;
using WaterPoint.Api.Common;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Contracts.JobCostItems;
using WaterPoint.Core.Domain.Payloads.JobCostItems;
using WaterPoint.Core.Domain.Payloads.Jobs;
using WaterPoint.Core.Domain.RequestParameters;
using WaterPoint.Core.Domain.Requests.JobCostItems;

namespace WaterPoint.Api.Job.Controllers
{
    [Authorize]
    [RoutePrefix(RouteDefinitions.Jobs.CostItemsPrefix)]
    public class CostItemsController : BaseOrgnizationContextController
    {
        private readonly IWriteRequestProcessor<CreateJobCostItemRequest> _createJobCostItemRequest;
        private readonly ISimplePagedProcessor<ListJobCostItemsRequest, JobCostItemBasicContract> _listJobCostItemequestProcessor;
        private readonly IWriteRequestProcessor<UpdateJobCostItemRequest> _updateRequestProcessor;
        private readonly IRequestProcessor<GetJobCostItemRequest, JobCostItemContract> _getJobCostItemProcessor;

        public CostItemsController(
            IWriteRequestProcessor<CreateJobCostItemRequest> createJobCostItemRequest,
            ISimplePagedProcessor<ListJobCostItemsRequest, JobCostItemBasicContract> listJobCostItemequestProcessor,
            IWriteRequestProcessor<UpdateJobCostItemRequest> updateRequestProcessor,
            IRequestProcessor<GetJobCostItemRequest, JobCostItemContract> getJobCostItemProcessor
            )
        {
            _listJobCostItemequestProcessor = listJobCostItemequestProcessor;
            _createJobCostItemRequest = createJobCostItemRequest;
            _updateRequestProcessor = updateRequestProcessor;
            _getJobCostItemProcessor = getJobCostItemProcessor;
        }

        [Route("")]
        public IHttpActionResult Get([FromUri]ListJobCostItemsRequest request)
        {
            var result = _listJobCostItemequestProcessor.Process(request);

            return Ok(result);
        }

        [Route("{id:int}")]
        public IHttpActionResult Get([FromUri]GetJobCostItemRequest request)
        {
            var result = _getJobCostItemProcessor.Process(request);

            return Ok(result);
        }

        [Route("")]
        public IHttpActionResult Post(
            [FromUri]CreateJobCostItemRequest request,
            [FromBody]WriteJobCostItemPayload jobCostItemPayload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestWithErrors(ModelState);
            }

            request.Payload = jobCostItemPayload;
            request.OrganizationUserId = OrganizationUser.Id;

            var result = _createJobCostItemRequest.Process(request);

            return Ok(result);
        }

        [Route("{id:int}")]
        public IHttpActionResult Put(
            [FromUri]UpdateJobCostItemRequest request,
            [FromBody]Delta<WriteJobCostItemPayload> input)
        {
            request.Payload = input;
            request.OrganizationUserId = OrganizationUser.Id;

            var jobCostItem = _updateRequestProcessor.Process(request);

            return Ok(jobCostItem);
        }
    }
}
