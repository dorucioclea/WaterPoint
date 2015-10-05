using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WaterPoint.Api.Common;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.RequestProcessor.Customers;
using WaterPoint.Core.Domain.Requests.Customers;
using WaterPoint.Core.RequestProcessor.Contracts.Customers;

namespace WaterPoint.Api.Customer.Controllers
{
    [RoutePrefix(RouteDefinitions.Cusotmers.Prefix)]
    public class CusotmersController : BaseOrgnizationContextController
    {
        private readonly IRequestProcessor<PaginatedCustomersRequest, IEnumerable<BasicCustomer>> _listCustomeRequestProcessor;

        public CusotmersController(
            IRequestProcessor<PaginatedCustomersRequest, IEnumerable<BasicCustomer>> listCustomeRequestProcessor)
        {
            _listCustomeRequestProcessor = listCustomeRequestProcessor;
        }

        public IHttpActionResult Get([FromUri]PaginatedCustomersRequest request)
        {
            //validation
            var result = _listCustomeRequestProcessor.Process(request);

            return Ok(result);
        }
    }
}
