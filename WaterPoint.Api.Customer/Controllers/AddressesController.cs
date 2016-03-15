using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Addresses;
using WaterPoint.Core.Domain.Contracts.Contacts;
using WaterPoint.Core.Domain.Payloads.Addresses;
using WaterPoint.Core.Domain.Requests.Addresses;

namespace WaterPoint.Api.Customer.Controllers
{
    [Authorize]
    [RoutePrefix("organizations/{organizationId:int}")]
    public class AddressesController : BaseOrgnizationContextController
    {
        private readonly IListProcessor<ListCustomerAddressesRequest, CustomerAddressContract> _listProcessor;
        private readonly IWriteRequestProcessor<CreateCustomerAddressRequest> _createProcessor;
        private readonly IRequestProcessor<GetCustomerAddressRequest, CustomerAddressContract> _getAddressProcessor;
        private readonly IWriteRequestProcessor<UpdateCustomerAddressRequest> _updateAddressProcessor;

        public AddressesController(
            IListProcessor<ListCustomerAddressesRequest, CustomerAddressContract> listProcessor,
            IWriteRequestProcessor<CreateCustomerAddressRequest> createProcessor,
            IRequestProcessor<GetCustomerAddressRequest, CustomerAddressContract> getAddressProcessor,
            IWriteRequestProcessor<UpdateCustomerAddressRequest> updateAddressProcessor)
        {
            _listProcessor = listProcessor;
            _createProcessor = createProcessor;
            _getAddressProcessor = getAddressProcessor;
            _updateAddressProcessor = updateAddressProcessor;
        }

        [Route("customers/{customerId:int}/addresses")]
        public IHttpActionResult Get([FromUri]ListCustomerAddressesRequest request)
        {
            var result = _listProcessor.Process(request);

            return Ok(result);
        }

        [Route("customers/{customerId:int}/addresses")]
        public IHttpActionResult Post(
            [FromUri]CreateCustomerAddressRequest request,
            [FromBody]WriteCustomerAddressPayload payload)
        {
            if (!ModelState.IsValid)
                return BadRequestWithErrors();

            request.Payload = payload;

            var result = _createProcessor.Process(request);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest();
        }

        [Route("customers/{customerId:int}/addresses/{id:int}")]
        public IHttpActionResult Get(
            [FromUri]GetCustomerAddressRequest request)
        {
            var result = _getAddressProcessor.Process(request);

            return Ok(result);
        }

        [Route("customers/{customerId:int}/addresses/{id:int}")]
        public IHttpActionResult Put(
            [FromUri]UpdateCustomerAddressRequest request,
            [FromBody]Delta<WriteAddressPayload> payload)
        {
            request.Payload = payload;

            var result = _updateAddressProcessor.Process(request);

            return Ok(result);
        }
    }
}
