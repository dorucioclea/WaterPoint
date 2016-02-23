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
        private readonly IListProcessor<ListAddressesForCustomerRequest, AddressContract> _listProcessor;
        private readonly IWriteRequestProcessor<CreateAddressForCustomerRequest> _createProcessor;
        private readonly IRequestProcessor<GetAddressForCustomerRequest, AddressContract> _getAddressProcessor;
        private readonly IWriteRequestProcessor<UpdateAddressRequest> _updateAddressProcessor;

        public AddressesController(
            IListProcessor<ListAddressesForCustomerRequest, AddressContract> listProcessor,
            IWriteRequestProcessor<CreateAddressForCustomerRequest> createProcessor,
            IRequestProcessor<GetAddressForCustomerRequest, AddressContract> getAddressProcessor,
            IWriteRequestProcessor<UpdateAddressRequest> updateAddressProcessor
            )
        {
            _listProcessor = listProcessor;
            _createProcessor = createProcessor;
            _getAddressProcessor = getAddressProcessor;
            _updateAddressProcessor = updateAddressProcessor;
        }

        [Route("customers/{customerId:int}/addresses")]
        public IHttpActionResult Get([FromUri]ListAddressesForCustomerRequest request)
        {
            var result = _listProcessor.Process(request);

            return Ok(result);
        }

        [Route("customers/{customerId:int}/addresses")]
        public IHttpActionResult Post(
            [FromUri]CreateAddressForCustomerRequest request,
            [FromBody]WriteAddressPayload payload)
        {
            if (!ModelState.IsValid)
                return BadRequestWithErrors(ModelState);

            request.Payload = payload;

            var result = _createProcessor.Process(request);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest();
        }

        [Route("customers/{customerId:int}/addresses/{id:int}")]
        public IHttpActionResult Get(
            [FromUri]GetAddressForCustomerRequest request)
        {
            var result = _getAddressProcessor.Process(request);

            return Ok(result);
        }

        [Route("customers/{customerId:int}/addresses/{id:int}")]
        public IHttpActionResult Put(
            [FromUri]UpdateAddressRequest request,
            [FromBody]Delta<WriteAddressPayload> payload)
        {
            request.Payload = payload;

            var result = _updateAddressProcessor.Process(request);

            return Ok(result);
        }
    }
}
