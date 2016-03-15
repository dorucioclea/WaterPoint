using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.QuoteCostItems;
using WaterPoint.Core.Domain.Payloads.QuoteCostItems;
using WaterPoint.Core.Domain.Requests.QuoteCostItems;

namespace WaterPoint.Api.Quote.Controllers
{
    [RoutePrefix("organizations/{organizationId:int}")]
    public class CostItemsController : BaseOrgnizationContextController
    {
        private readonly IWriteRequestProcessor<CreateQuoteCostItemRequest> _createProcessor;
        private readonly ISimplePagedProcessor<ListQuoteCostItemsRequest, QuoteCostItemBasicContract> _listProcessor;
        private readonly IRequestProcessor<GetQuoteCostItemRequest, QuoteCostItemContract> _getProcessor;
        private readonly IWriteRequestProcessor<UpdateQuoteCostItemRequest> _updateProcessor;

        public CostItemsController(
            IWriteRequestProcessor<CreateQuoteCostItemRequest> createProcessor,
            ISimplePagedProcessor<ListQuoteCostItemsRequest, QuoteCostItemBasicContract> listProcessor,
            IRequestProcessor<GetQuoteCostItemRequest, QuoteCostItemContract> getProcessor,
            IWriteRequestProcessor<UpdateQuoteCostItemRequest> updateProcessor)
        {
            _createProcessor = createProcessor;
            _listProcessor = listProcessor;
            _getProcessor = getProcessor;
            _updateProcessor = updateProcessor;
        }

        [Route("customers/{customerId:int}/quotes/{quoteId:int}/costs")]
        public IHttpActionResult Post(
            [FromUri]CreateQuoteCostItemRequest request,
            [FromBody]CreateQuoteCostItemPayload payload)
        {
            request.Payload = payload;

            var result = _createProcessor.Process(request);

            return Ok(result);
        }

        [Route("quotes/{quoteId:int}/tasks")]
        public IHttpActionResult Get([FromUri]ListQuoteCostItemsRequest request)
        {
            var result = _listProcessor.Process(request);

            return Ok(result);
        }

        [Route("quotes/{quoteId:int}/tasks/{id:int}")]
        public IHttpActionResult Get([FromUri]GetQuoteCostItemRequest request)
        {
            var result = _getProcessor.Process(request);

            return Ok(result);
        }


        [Route("quotes/{quoteId:int}/tasks/{id:int}")]
        public IHttpActionResult Put(
            [FromUri]UpdateQuoteCostItemRequest request,
            [FromBody]Delta<UpdateQuoteCostItemPayload> payload)
        {
            if (!ModelState.IsValid)
                return BadRequestWithErrors();

            request.Payload = payload;

            var result = _updateProcessor.Process(request);

            return Ok(result);
        }
    }
}
