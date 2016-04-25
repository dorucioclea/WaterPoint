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
using WaterPoint.Core.Domain.Requests;
using WaterPoint.Core.Domain.Requests.JobCostItems;

namespace WaterPoint.Api.Job.Controllers
{
    [Authorize]
    [RoutePrefix("organizations/{organizationId}/jobs/{jobId:int}/costitems")]
    public class CostItemsController : BaseOrgnizationContextController
    {
        private readonly IWriteRequestProcessor<CreateJobCostItemRequest> _createJobCostItemRequest;
        private readonly IListProcessor<ListJobCostItemsRequest, JobCostItemBasicContract> _listJobCostItemequestProcessor;
        private readonly IWriteRequestProcessor<UpdateJobCostItemRequest> _updateRequestProcessor;
        private readonly IRequestProcessor<GetJobCostItemRequest, JobCostItemContract> _getJobCostItemProcessor;
        private readonly IDeleteRequestProcessor<OrganizationEntityRequest> _deleteProcessor;

        public CostItemsController(
            IWriteRequestProcessor<CreateJobCostItemRequest> createJobCostItemRequest,
            IListProcessor<ListJobCostItemsRequest, JobCostItemBasicContract> listJobCostItemequestProcessor,
            IWriteRequestProcessor<UpdateJobCostItemRequest> updateRequestProcessor,
            IRequestProcessor<GetJobCostItemRequest, JobCostItemContract> getJobCostItemProcessor,
            IDeleteRequestProcessor<OrganizationEntityRequest> deleteProcessor
            )
        {
            _listJobCostItemequestProcessor = listJobCostItemequestProcessor;
            _createJobCostItemRequest = createJobCostItemRequest;
            _updateRequestProcessor = updateRequestProcessor;
            _getJobCostItemProcessor = getJobCostItemProcessor;
            _deleteProcessor = deleteProcessor;
        }

        [Route("")]
        public IHttpActionResult Get([FromUri]ListJobCostItemsRequest request)
        {
            var result = _listJobCostItemequestProcessor.Process(request);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [Route("{id:int}")]
        public IHttpActionResult Get([FromUri]GetJobCostItemRequest request)
        {
            var result = _getJobCostItemProcessor.Process(request);

            if(result == null)
                return NotFound();

            return Ok(result);
        }

        [Route("")]
        public IHttpActionResult Post(
            [FromUri]CreateJobCostItemRequest request,
            [FromBody]WriteJobCostItemPayload jobCostItemPayload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestWithErrors();
            }

            request.Payload = jobCostItemPayload;
            request.OrganizationUserId = Credential.OrganizationUserId;

            var result = _createJobCostItemRequest.Process(request);

            return Ok(result);
        }

        [Route("{id:int}")]
        public IHttpActionResult Put(
            [FromUri]UpdateJobCostItemRequest request,
            [FromBody]Delta<WriteJobCostItemPayload> input)
        {
            request.Payload = input;
            request.OrganizationUserId = Credential.OrganizationUserId;

            var jobCostItem = _updateRequestProcessor.Process(request);

            return Ok(jobCostItem);
        }

        [Route("{id:int}")]
        public IHttpActionResult Delete([FromUri]OrganizationEntityRequest request)
        {
            var result = _deleteProcessor.Process(request);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest();
        }
    }
}
