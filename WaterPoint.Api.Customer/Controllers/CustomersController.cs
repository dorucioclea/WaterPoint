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
        private readonly IRequestProcessor<PaginationWithOrgIdRequest, PaginatedResult<IEnumerable<CustomerContract>>> _listCustomeRequestProcessor;
        private readonly IRequestProcessor<CreateCustomerRequest, CustomerContract> _createCustomerRequest;
        private readonly IRequestProcessor<UpdateCustomerRequest, CustomerContract> _updateRequestProcessor;
        private readonly IRequestProcessor<GetCustomerByIdRequest, CustomerContract> _getCustomerByIdProcessor;


        public CustomersController(
            IRequestProcessor<PaginationWithOrgIdRequest, PaginatedResult<IEnumerable<CustomerContract>>> listCustomeRequestProcessor,
            IRequestProcessor<CreateCustomerRequest, CustomerContract> createCustomerRequest,
            IRequestProcessor<UpdateCustomerRequest, CustomerContract> updateRequestProcessor,
            IRequestProcessor<GetCustomerByIdRequest, CustomerContract> getCustomerByIdProcessor)
        {
            _listCustomeRequestProcessor = listCustomeRequestProcessor;
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
            var request = new PaginationWithOrgIdRequest
            {
                OrganizationIdParameter = parameter,
                PaginationParamter = pagination
            };

            var result = _listCustomeRequestProcessor.Process(request);

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

            //TODO: add staff id
            var result = _createCustomerRequest.Process(
                new CreateCustomerRequest
                {
                    OrganizationIdParameter = parameter,
                    CreateCustomerPayload = customerPayload,
                    StaffId = Staff.Id
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
                    StaffId = Staff.Id
                });

            return Ok(customer);
        }
    }
}
