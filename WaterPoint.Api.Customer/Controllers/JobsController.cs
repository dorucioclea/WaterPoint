using System.Web.Http;
using WaterPoint.Api.Common;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Dtos;
using WaterPoint.Core.Domain.Dtos.RequestParameters;
using WaterPoint.Core.Domain.Dtos.Requests.Customers;

namespace WaterPoint.Api.Customer.Controllers
{
    [RoutePrefix(RouteDefinitions.Customers.Prefix)]
    public class JobsController : BaseOrgnizationContextController
    {
        private readonly IRequestProcessor<ListCustomerJobsRequest, PaginatedResult<JobWithCustomerContract>> _listCustomerJobsRequestProcessor;

        public JobsController(
            IRequestProcessor<ListCustomerJobsRequest, PaginatedResult<JobWithCustomerContract>> listCustomerJobsRequestProcessor)
        {
            _listCustomerJobsRequestProcessor = listCustomerJobsRequestProcessor;
        }

        [Route(RouteDefinitions.Customers.Jobs)]
        public IHttpActionResult Get(
            [FromUri]CustomerIdOrgIdRp customerIdOrgIdRp,
            [FromUri]PaginationRp paginationParamter)
        {
            var request = new ListCustomerJobsRequest
            {
                CustomerIdOrgIdRp = customerIdOrgIdRp,
                PaginationParamter = paginationParamter
            };

            var result = _listCustomerJobsRequestProcessor.Process(request);

            return Ok(result);
        }
    }
}
