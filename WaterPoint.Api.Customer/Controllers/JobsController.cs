using System.Web.Http;
using WaterPoint.Api.Common;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Jobs;

using WaterPoint.Core.Domain.RequestParameters;
using WaterPoint.Core.Domain.Requests.Customers;

namespace WaterPoint.Api.Customer.Controllers
{
    [RoutePrefix(RouteDefinitions.Customers.JobsPrefix)]
    public class JobsController : BaseOrgnizationContextController
    {
        private readonly IRequestProcessor<ListCustomerJobsRequest, SimplePaginatedResult<JobWithStatusContract>> _listCustomerJobsRequestProcessor;

        public JobsController(
            IRequestProcessor<ListCustomerJobsRequest, SimplePaginatedResult<JobWithStatusContract>> listCustomerJobsRequestProcessor)
        {
            _listCustomerJobsRequestProcessor = listCustomerJobsRequestProcessor;
        }

        [Route("")]
        public IHttpActionResult Get(
            [FromUri]OrgIdCusIdRp parameter,
            [FromUri]PaginationRp pagination)
        {
            var request = new ListCustomerJobsRequest
            {
                Parameter = parameter,
                Pagination = pagination
            };

            var result = _listCustomerJobsRequestProcessor.Process(request);

            return Ok(result);
        }
    }
}
