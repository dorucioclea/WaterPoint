using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.OData;
using WaterPoint.Api.Common;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Dtos;
using WaterPoint.Core.Domain.Dtos.Payloads.Customers;
using WaterPoint.Core.Domain.Dtos.RequestParameters;
using WaterPoint.Core.Domain.Dtos.Requests.Customers;

namespace WaterPoint.Api.Customer.Controllers
{
    [RoutePrefix(RouteDefinitions.Customers.Prefix)]
    public class CustomersController : BaseOrgnizationContextController
    {
        private readonly IRequestProcessor<ListCustomersRequest, PaginatedResult<IEnumerable<CustomerContract>>> _listCustomerRequestProcessor;
        private readonly IRequestProcessor<CreateCustomerRequest, CustomerContract> _createCustomerRequest;
        private readonly IRequestProcessor<UpdateCustomerRequest, CustomerContract> _updateRequestProcessor;
        private readonly IRequestProcessor<GetCustomerRequest, CustomerContract> _getCustomerByIdProcessor;


        public CustomersController(
            IRequestProcessor<ListCustomersRequest, PaginatedResult<IEnumerable<CustomerContract>>> listCustomerRequestProcessor,
            IRequestProcessor<CreateCustomerRequest, CustomerContract> createCustomerRequest,
            IRequestProcessor<UpdateCustomerRequest, CustomerContract> updateRequestProcessor,
            IRequestProcessor<GetCustomerRequest, CustomerContract> getCustomerByIdProcessor)
        {
            _listCustomerRequestProcessor = listCustomerRequestProcessor;
            _createCustomerRequest = createCustomerRequest;
            _updateRequestProcessor = updateRequestProcessor;
            _getCustomerByIdProcessor = getCustomerByIdProcessor;
        }

        [Route("")]
        public IHttpActionResult Get(
            [FromUri]IsProspectOrgIdParameter parameter,
            [FromUri]PaginationParamter pagination)
        {
            //validation
            var request = new ListCustomersRequest
            {
                IsProspectOrgId = parameter,
                Pagination = pagination
            };

            var result = _listCustomerRequestProcessor.Process(request);

            return Ok(result);
        }

        [Route("{id:int}")]
        public IHttpActionResult Get([FromUri]OrganizationEntityParameter parameter)
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
            [FromUri]OrgIdParameter parameter,
            [FromBody]WriteCustomerPayload customerPayload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
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
            [FromUri] OrganizationEntityParameter parameter,
            [FromBody] Delta<WriteCustomerPayload> input)
        {
            //map customer to an updatecustomerrequest so it gets all data
            //input.Patch(updatecustomerrequest) to get the patched value
            //pass patched value to processor
            var customer = _updateRequestProcessor.Process(
                new UpdateCustomerRequest
                {
                    OrganizationEntityParameter = parameter,
                    UpdateCustomerPayload = input,
                    OrganizationUserId = OrganizationUser.Id
                });

            return Ok(customer);
        }
    }
}
