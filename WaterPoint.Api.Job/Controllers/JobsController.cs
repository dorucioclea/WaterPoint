using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WaterPoint.Api.Common;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Dtos.Customers.Requests;

namespace WaterPoint.Api.Job.Controllers
{
    public class JobsController : ApiController
    {
        private readonly IRequestProcessor<PaginationWithOrgIdRequest, PaginatedResult<IEnumerable<JobContract>>> _listCustomeRequestProcessor;

        public JobsController(
            IRequestProcessor<PaginationWithOrgIdRequest, PaginatedResult<IEnumerable<JobContract>>> listCustomeRequestProcessor)
        {
            _listCustomeRequestProcessor = listCustomeRequestProcessor;
        }

        public
    }
}
