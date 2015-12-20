using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utility;
using WaterPoint.Api.Common;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Dtos;
using WaterPoint.Core.Domain.Dtos.Parameters;
using WaterPoint.Core.Domain.Dtos.Requests.Customers;

namespace WaterPoint.Api.Customer.Controllers
{
    [RoutePrefix(RouteDefinitions.Customers.Prefix)]
    public class JobsController : BaseOrgnizationContextController
    {
        private readonly IRequestProcessor<ListPaginatedCustomerJobsRequest, JobWithCustomerAndStatusContract> _listCustomerJobsRequestProcessor;

        public JobsController(
            IRequestProcessor<ListPaginatedCustomerJobsRequest, JobWithCustomerAndStatusContract> listCustomerJobsRequestProcessor)
        {
            _listCustomerJobsRequestProcessor = listCustomerJobsRequestProcessor;
        }

        [Route(RouteDefinitions.Customers.Jobs)]
        public IHttpActionResult Get(
            [FromUri]CustomerIdOrgIdParameter customerIdOrgIdParameter,
            [FromUri]PaginationParamter paginationParamter)
        {
            var request = new ListPaginatedCustomerJobsRequest
            {
                CustomerIdOrgIdParameter = customerIdOrgIdParameter,
                PaginationParamter = paginationParamter
            };

            var result = _listCustomerJobsRequestProcessor.Process(request);

            return Ok(result);
        }
    }
}
