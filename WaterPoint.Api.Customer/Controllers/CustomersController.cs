using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.OData;
using WaterPoint.Api.Common;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Contracts.Customers;

using WaterPoint.Core.Domain.Payloads.Customers;
using WaterPoint.Core.Domain.RequestParameters;
using WaterPoint.Core.Domain.Requests.Customers;

namespace WaterPoint.Api.Customer.Controllers
{
    [RoutePrefix(RouteDefinitions.Customers.Prefix)]
    public class CustomersController : BaseOrgnizationContextController
    {
        private readonly IPaginatedProcessor<ListCustomersRequest, CustomerContract> _listCustomerRequestProcessor;
        private readonly IWriteRequestProcessor<CreateCustomerRequest> _createCustomerRequest;
        private readonly IWriteRequestProcessor<UpdateCustomerRequest> _updateRequestProcessor;
        private readonly IRequestProcessor<GetCustomerRequest, CustomerContract> _getCustomerByIdProcessor;


        public CustomersController(
            IPaginatedProcessor<ListCustomersRequest, CustomerContract> listCustomerRequestProcessor,
            IWriteRequestProcessor<CreateCustomerRequest> createCustomerRequest,
            IWriteRequestProcessor<UpdateCustomerRequest> updateRequestProcessor,
            IRequestProcessor<GetCustomerRequest, CustomerContract> getCustomerByIdProcessor)
        {
            _listCustomerRequestProcessor = listCustomerRequestProcessor;
            _createCustomerRequest = createCustomerRequest;
            _updateRequestProcessor = updateRequestProcessor;
            _getCustomerByIdProcessor = getCustomerByIdProcessor;
        }

        [Route("")]
        public IHttpActionResult Get([FromUri]ListCustomersRequest request)
        {
            var result = _listCustomerRequestProcessor.Process(request);

            return Ok(result);
        }

        [Route("{id:int}")]
        public IHttpActionResult Get([FromUri]GetCustomerRequest request)
        {
            var result = _getCustomerByIdProcessor.Process(request);

            return Ok(result);
        }

        [Route("")]
        [Authorize]//add to class level
        public IHttpActionResult Post(
            [FromUri]CreateCustomerRequest request,
            [FromBody]WriteCustomerPayload payload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestWithErrors(ModelState);
            }

            request.Payload = payload;
            request.OrganizationUserId = OrganizationUser.Id;

            var result = _createCustomerRequest.Process(request);

            return Ok(result);
        }

        [Route("{id:int}")]
        [Authorize]
        public IHttpActionResult Put(
            [FromUri]UpdateCustomerRequest request,
            [FromBody]Delta<WriteCustomerPayload> input)
        {
            //map customer to an updatecustomerrequest so it gets all data
            //input.Patch(updatecustomerrequest) to get the patched value
            //pass patched value to processor
            request.Payload = input;
            request.OrganizationUserId = OrganizationUser.Id;

            var customer = _updateRequestProcessor.Process(request);

            return Ok(customer);
        }
    }
}
