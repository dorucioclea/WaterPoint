using System.Web.Http;
using WaterPoint.Api.Common;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.CostItems;
using WaterPoint.Core.Domain.Dtos;
using WaterPoint.Core.Domain.Dtos.Payloads.CostItems;
using WaterPoint.Core.Domain.Dtos.Requests.CostItems;

namespace WaterPoint.Api.CostItem.Controllers
{
    [RoutePrefix(RouteDefinitions.CostItems.Prefix)]
    public class CostItemsController : BaseOrgnizationContextController
    {
        private readonly IRequestProcessor<CreateCostItemRequest, CostItemContract> _createRequestProcessor;
        private readonly IRequestProcessor<GetCostItemRequest, CostItemContract> _getRequestProcessor;

        public CostItemsController(
            IRequestProcessor<CreateCostItemRequest, CostItemContract> createRequestProcessor,
            IRequestProcessor<GetCostItemRequest, CostItemContract> getRequestProcessor)
        {
            _createRequestProcessor = createRequestProcessor;
            _getRequestProcessor = getRequestProcessor;
        }

        [Route("{id:int}")]
        public IHttpActionResult Get([FromUri]OrganizationEntityParameter parameter)
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
            [FromUri]OrgIdParameter orgId,
            [FromUri] WriteCostItemPayload payload)
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
    }
}
