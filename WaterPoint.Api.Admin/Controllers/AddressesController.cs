using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Payloads.Addresses;
using WaterPoint.Core.Domain.Requests.Addresses;

namespace WaterPoint.Api.Admin.Controllers
{
    [Authorize]
    [RoutePrefix("organizations/{organizationId:int}/addresses")]
    public class AddressesController : BaseOrgnizationContextController
    {
        private readonly IWriteRequestProcessor<CreateAddressRequest> _createProcessor;
        private readonly IWriteRequestProcessor<UpdateAddressRequest> _updateAddressProcessor;

        public AddressesController(
            IWriteRequestProcessor<CreateAddressRequest> createProcessor,
            IWriteRequestProcessor<UpdateAddressRequest> updateAddressProcessor)
        {
            _createProcessor = createProcessor;
            _updateAddressProcessor = updateAddressProcessor;
        }

        [Route("")]
        public IHttpActionResult Post(
            [FromUri]CreateAddressRequest request,
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

        [Route("{id:int}")]
        public IHttpActionResult Put(
            [FromUri]UpdateAddressRequest request,
            [FromBody]Delta<WriteAddressPayload> payload)
        {
            request.Payload = payload;

            var address = _updateAddressProcessor.Process(request);

            return Ok(address);
        }
    }
}
