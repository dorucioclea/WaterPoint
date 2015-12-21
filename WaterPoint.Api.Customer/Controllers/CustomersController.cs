using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.OData;
using WaterPoint.Api.Common;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Dtos;
using WaterPoint.Core.Domain.Dtos.Payloads.Customers;
using WaterPoint.Core.Domain.Dtos.Requests.Customers;
using WaterPoint.Core.Domain.Dtos.Requests.Shared;

namespace WaterPoint.Api.Customer.Controllers
{
    [RoutePrefix(RouteDefinitions.Customers.Prefix)]
    public class CustomersController : BaseOrgnizationContextController
    {
        private readonly IRequestProcessor<ListPaginatedWithOrgIdRequest, PaginatedResult<IEnumerable<CustomerContract>>> _listCustomerRequestProcessor;
        private readonly IRequestProcessor<CreateCustomerRequest, CustomerContract> _createCustomerRequest;
        private readonly IRequestProcessor<UpdateCustomerRequest, CustomerContract> _updateRequestProcessor;
        private readonly IRequestProcessor<GetCustomerByIdRequest, CustomerContract> _getCustomerByIdProcessor;


        public CustomersController(
            IRequestProcessor<ListPaginatedWithOrgIdRequest, PaginatedResult<IEnumerable<CustomerContract>>> listCustomerRequestProcessor,
            IRequestProcessor<CreateCustomerRequest, CustomerContract> createCustomerRequest,
            IRequestProcessor<UpdateCustomerRequest, CustomerContract> updateRequestProcessor,
            IRequestProcessor<GetCustomerByIdRequest, CustomerContract> getCustomerByIdProcessor)
        {
            _listCustomerRequestProcessor = listCustomerRequestProcessor;
            _createCustomerRequest = createCustomerRequest;
            _updateRequestProcessor = updateRequestProcessor;
            _getCustomerByIdProcessor = getCustomerByIdProcessor;
        }

        [Route("")]
        public IHttpActionResult Get(
            [FromUri]OrganizationIdParameter parameter,
            [FromUri]PaginationParamter pagination)
        {
            //validation
            var request = new ListPaginatedWithOrgIdRequest
            {
                OrganizationIdParameter = parameter,
                PaginationParamter = pagination
            };

            var result = _listCustomerRequestProcessor.Process(request);

            return Ok(result);
        }

        [Route("{id:int}")]
        public IHttpActionResult Get([FromUri]OrganizationEntityParameter parameter)
        {
            var result = _getCustomerByIdProcessor.Process(
                new GetCustomerByIdRequest
                {
                    OrganizationEntityParameter = parameter
                });

            return Ok(result);
        }

        [Route("")]
        public IHttpActionResult Post(
            [FromUri]OrganizationIdParameter parameter,
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
