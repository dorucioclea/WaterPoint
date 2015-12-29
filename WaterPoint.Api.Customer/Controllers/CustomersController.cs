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
        private readonly IRequestProcessor<ListCustomersRequest, PaginatedResult<CustomerContract>> _listCustomerRequestProcessor;
        private readonly IRequestProcessor<CreateCustomerRequest, CommandResultContract> _createCustomerRequest;
        private readonly IRequestProcessor<UpdateCustomerRequest, CommandResultContract> _updateRequestProcessor;
        private readonly IRequestProcessor<GetCustomerRequest, CustomerContract> _getCustomerByIdProcessor;


        public CustomersController(
            IRequestProcessor<ListCustomersRequest, PaginatedResult<CustomerContract>> listCustomerRequestProcessor,
            IRequestProcessor<CreateCustomerRequest, CommandResultContract> createCustomerRequest,
            IRequestProcessor<UpdateCustomerRequest, CommandResultContract> updateRequestProcessor,
            IRequestProcessor<GetCustomerRequest, CustomerContract> getCustomerByIdProcessor)
        {
            _listCustomerRequestProcessor = listCustomerRequestProcessor;
            _createCustomerRequest = createCustomerRequest;
            _updateRequestProcessor = updateRequestProcessor;
            _getCustomerByIdProcessor = getCustomerByIdProcessor;
        }

        [Route("")]
        public IHttpActionResult Get([FromUri]ListCustomerRp parameter)
        {
            //validation
            var request = new ListCustomersRequest { Parameter = parameter };

            var result = _listCustomerRequestProcessor.Process(request);

            return Ok(result);
        }

        [Route("{id:int}")]
        public IHttpActionResult Get([FromUri]OrgEntityRp parameter)
        {
            var result = _getCustomerByIdProcessor.Process(
                new GetCustomerRequest
                {
                    OrganizationEntityParameter = parameter
                });

            return Ok(result);
        }

        [Route("")]
        [Authorize]//add to class level
        public IHttpActionResult Post(
            [FromUri]OrgIdRp parameter,
            [FromBody]WriteCustomerPayload customerPayload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestWithErrors(ModelState);
            }

            //TODO: add OrganizationUser id
            var result = _createCustomerRequest.Process(
                new CreateCustomerRequest
                {
                    OrganizationIdParameter = parameter,
                    CreateCustomerPayload = customerPayload,
                    OrganizationUserId = OrganizationUser.Id
                });

            return Ok(result);
        }

        [Route("{id:int}")]
        [Authorize]
        public IHttpActionResult Put(
            [FromUri] OrgEntityRp parameter,
            [FromBody] Delta<WriteCustomerPayload> input)
        {
            //map customer to an updatecustomerrequest so it gets all data
            //input.Patch(updatecustomerrequest) to get the patched value
            //pass patched value to processor
            var customer = _updateRequestProcessor.Process(
                new UpdateCustomerRequest
                {
                    Parameter = parameter,
                    Payload = input,
                    OrganizationUserId = OrganizationUser.Id
                });

            return Ok(customer);
        }
    }
}
