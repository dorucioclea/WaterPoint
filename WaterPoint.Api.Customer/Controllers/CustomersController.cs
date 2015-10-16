using System.Collections.Generic;
using System.Web.Http;
using WaterPoint.Api.Common;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Requests.Customers;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Requests;

namespace WaterPoint.Api.Customer.Controllers
{
    [RoutePrefix(RouteDefinitions.Cusotmers.Prefix)]
    public class CusotmersController : BaseOrgnizationContextController
    {
        private readonly IRequestProcessor<OrganizationIdRequest, PaginationRequest, PaginatedResult<IEnumerable<BasicCustomer>>> _listCustomeRequestProcessor;

        public CusotmersController(
            IRequestProcessor<OrganizationIdRequest, PaginationRequest, PaginatedResult<IEnumerable<BasicCustomer>>> listCustomeRequestProcessor)
        {
            _listCustomeRequestProcessor = listCustomeRequestProcessor;
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
    }
}

