using System.Collections.Generic;
using System.Web.Http;
using WaterPoint.Api.Common;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Requests;
using WaterPoint.Core.Domain.Requests.Customers;
using WaterPoint.Core.RequestProcessor.Customers;
using CreateCustomerRequest = WaterPoint.Core.Domain.Requests.Customers.CreateCustomerRequest;

namespace WaterPoint.Api.Customer.Controllers
{
    [RoutePrefix(RouteDefinitions.Cusotmers.Prefix)]
    public class CusotmersController : BaseOrgnizationContextController
    {
        private readonly IRequestProcessor<OrganizationIdRequest, PaginationRequest,
                PaginatedResult<IEnumerable<BasicCustomerWithAddress>>> _listCustomeRequestProcessor;

        private readonly ICreateRequestProcessor<OrganizationIdRequest, CreateCustomerRequest, BasicCustomer> _createCustomerRequest;

        public CusotmersController(
            IRequestProcessor<OrganizationIdRequest, PaginationRequest,
                    PaginatedResult<IEnumerable<BasicCustomerWithAddress>>> listCustomeRequestProcessor,
            ICreateRequestProcessor<OrganizationIdRequest, CreateCustomerRequest, BasicCustomer> createCustomerRequest)
        {
            _listCustomeRequestProcessor = listCustomeRequestProcessor;
            _createCustomerRequest = createCustomerRequest;
        }

        [Route("")]
        public IHttpActionResult Get(
            [FromUri]OrganizationIdRequest request,
            [FromUri]PaginationRequest pagination)
        {
            //validation
            var result = _listCustomeRequestProcessor.Process(request, pagination);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [Route("")]
        public IHttpActionResult Post(
            [FromUri]OrganizationIdRequest request,
            [FromBody]CreateCustomerRequest customerInput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = _createCustomerRequest.Process(request, customerInput);

            return Ok(result);
        }
    }
}

