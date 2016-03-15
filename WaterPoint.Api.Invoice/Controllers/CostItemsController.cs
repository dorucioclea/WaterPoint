using System.Web.Http;
using System.Web.Http.OData;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.InvoiceCostItems;
using WaterPoint.Core.Domain.Payloads.InvoiceCostItems;
using WaterPoint.Core.Domain.Requests.InvoiceCostItems;

namespace WaterPoint.Api.Invoice.Controllers
{
    [RoutePrefix("organizations/{organizationId:int}/invoices")]
    public class CostItemsController : BaseOrgnizationContextController
    {
        private readonly IWriteRequestProcessor<CreateInvoiceCostItemRequest> _createProcessor;
        private readonly ISimplePagedProcessor<ListInvoiceCostItemsRequest, BasicInvoiceCostItemContract> _listProcessor;
        private readonly IWriteRequestProcessor<UpdateInvoiceCostItemRequest> _updateProcessor;

        public CostItemsController(
            IWriteRequestProcessor<CreateInvoiceCostItemRequest> createProcessor,
            ISimplePagedProcessor<ListInvoiceCostItemsRequest, BasicInvoiceCostItemContract> listProcessor,
            IWriteRequestProcessor<UpdateInvoiceCostItemRequest> updateProcessor
            )
        {
            _createProcessor = createProcessor;
            _listProcessor = listProcessor;
            _updateProcessor = updateProcessor;
        }

        [Route("")]
        public IHttpActionResult Post(
            [FromUri]CreateInvoiceCostItemRequest request,
            [FromBody]CreateInvoiceCostItemPayload payload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestWithErrors();
            }

            request.Payload = payload;

            var result = _createProcessor.Process(request);

            return Ok(result);
        }

        [Route("")]
        public IHttpActionResult Get([FromUri]ListInvoiceCostItemsRequest request)
        {
            var result = _listProcessor.Process(request);

            return Ok(result);
        }

        [Route("{id:int}")]
        public IHttpActionResult Put(
            [FromUri]UpdateInvoiceCostItemRequest request,
            [FromBody]Delta<UpdateInvoiceCostItemPayload> input)
        {
            request.Payload = input;

            var costitem = _updateProcessor.Process(request);

            return Ok(costitem);
        }
    }
}
