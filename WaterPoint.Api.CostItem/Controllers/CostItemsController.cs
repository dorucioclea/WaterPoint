using System.Web.Http;
using System.Web.Http.OData;
using WaterPoint.Api.Common;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Contracts.CostItems;
using WaterPoint.Core.Domain.Payloads.CostItems;
using WaterPoint.Core.Domain.RequestParameters;
using WaterPoint.Core.Domain.Requests.CostItems;

namespace WaterPoint.Api.CostItem.Controllers
{
    [RoutePrefix(RouteDefinitions.CostItems.Prefix)]
    public class CostItemsController : BaseOrgnizationContextController
    {
        private readonly IRequestProcessor<CreateCostItemRequest, CommandResultContract> _createRequestProcessor;
        private readonly IRequestProcessor<GetCostItemRequest, CostItemContract> _getRequestProcessor;
        private readonly IRequestProcessor<ListCostItemsRequest, PaginatedResult<CostItemContract>> _listRequestProcessor;
        private readonly IRequestProcessor<UpdateCostItemRequest, CommandResultContract> _updateRequestProcessor;

        public CostItemsController(
            IRequestProcessor<CreateCostItemRequest, CommandResultContract> createRequestProcessor,
            IRequestProcessor<GetCostItemRequest, CostItemContract> getRequestProcessor,
            IRequestProcessor<ListCostItemsRequest, PaginatedResult<CostItemContract>> listRequestProcessor,
            IRequestProcessor<UpdateCostItemRequest, CommandResultContract> updateRequestProcessor)
        {
            _createRequestProcessor = createRequestProcessor;
            _getRequestProcessor = getRequestProcessor;
            _listRequestProcessor = listRequestProcessor;
            _updateRequestProcessor = updateRequestProcessor;
        }

        [Route("")]
        public IHttpActionResult Get(
            [FromUri]OrgIdRp orgId,
            [FromUri]PaginationRp pagination)
        {
            var request = new ListCostItemsRequest
            {
                OrganizationId = orgId,
                Pagination = pagination
            };

            var result = _listRequestProcessor.Process(request);

            return Ok(result);
        }

        [Route("{id:int}")]
        public IHttpActionResult Get([FromUri]OrgEntityRp parameter)
        {
            var request = new GetCostItemRequest
            {
                OrganizationEntityParameter = parameter
            };

            var result = _getRequestProcessor.Process(request);

            return Ok(result);
        }

        [Route("")]
        public IHttpActionResult Post(
            [FromUri]OrgIdRp orgId,
            [FromUri]WriteCostItemPayload payload)
        {
            var request = new CreateCostItemRequest
            {
                CreateCustomerPayload = payload,
                OrganizationIdParameter = orgId,
                OrganizationUserId = OrganizationUser.Id
            };

            var result = _createRequestProcessor.Process(request);

            return Ok(result);
        }

        [Route("")]
        public IHttpActionResult Put(
            [FromUri]OrgEntityRp orgId,
            [FromUri]Delta<WriteCostItemPayload> payload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var request = new UpdateCostItemRequest
            {
                Payload = payload,
                Parameter = orgId,
                OrganizationUserId = OrganizationUser.Id
            };

            var result = _updateRequestProcessor.Process(request);

            return Ok(result);
        }
    }
}
