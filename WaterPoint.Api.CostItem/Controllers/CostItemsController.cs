using System.Web.Http;
using System.Web.Http.OData;
using WaterPoint.Api.Common;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Contracts.CostItems;
using WaterPoint.Core.Domain.Payloads.CostItems;
using WaterPoint.Core.Domain.RequestParameters;
using WaterPoint.Core.Domain.Requests;
using WaterPoint.Core.Domain.Requests.CostItems;

namespace WaterPoint.Api.CostItem.Controllers
{
    [Authorize]
    [RoutePrefix("organizations/{organizationId:int}/costitems")]
    public class CostItemsController : BaseOrgnizationContextController
    {
        private readonly IWriteRequestProcessor<CreateCostItemRequest> _createRequestProcessor;
        private readonly IRequestProcessor<GetCostItemRequest, CostItemContract> _getRequestProcessor;
        private readonly IPagedProcessor<ListCostItemsRequest, CostItemContract> _listRequestProcessor;
        private readonly IWriteRequestProcessor<UpdateCostItemRequest> _updateRequestProcessor;
        private readonly IDeleteRequestProcessor<OrganizationEntityRequest> _deleteRequestProcessor;

        public CostItemsController(
            IWriteRequestProcessor<CreateCostItemRequest> createRequestProcessor,
            IRequestProcessor<GetCostItemRequest, CostItemContract> getRequestProcessor,
            IPagedProcessor<ListCostItemsRequest, CostItemContract> listRequestProcessor,
            IWriteRequestProcessor<UpdateCostItemRequest> updateRequestProcessor,
            IDeleteRequestProcessor<OrganizationEntityRequest> deleteRequestProcessor)
        {
            _createRequestProcessor = createRequestProcessor;
            _getRequestProcessor = getRequestProcessor;
            _listRequestProcessor = listRequestProcessor;
            _updateRequestProcessor = updateRequestProcessor;
            _deleteRequestProcessor = deleteRequestProcessor;
        }

        [Route("")]
        public IHttpActionResult Get([FromUri]ListCostItemsRequest request)
        {
            var result = _listRequestProcessor.Process(request);

            return Ok(result);
        }

        [Route("{id:int}")]
        public IHttpActionResult Get([FromUri]GetCostItemRequest request)
        {
            var result = _getRequestProcessor.Process(request);

            return Ok(result);
        }

        [Route("")]
        public IHttpActionResult Post(
            [FromUri]CreateCostItemRequest request,
            [FromBody]WriteCostItemPayload payload)
        {
            request.Payload = payload;
            request.OrganizationUserId = Credential.OrganizationUserId;

            var result = _createRequestProcessor.Process(request);

            return Ok(result);
        }

        [Route("{id:int}")]
        public IHttpActionResult Put(
            [FromUri]UpdateCostItemRequest request,
            [FromBody]Delta<WriteCostItemPayload> payload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestWithErrors(ModelState);
            }

            request.Payload = payload;
            request.OrganizationUserId = Credential.OrganizationUserId;

            var result = _updateRequestProcessor.Process(request);

            return Ok(result);
        }

        [Route("{id:int}")]
        public IHttpActionResult Delete([FromUri]OrganizationEntityRequest request)
        {
            var result = _deleteRequestProcessor.Process(request);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest();
        }
    }
}
