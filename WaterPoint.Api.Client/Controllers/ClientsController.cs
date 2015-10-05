using System.Collections.Generic;
using System.Web.Http;
using WaterPoint.Api.Common;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Clients;
using WaterPoint.Core.Domain.Requests;
using WaterPoint.Core.Domain.Requests.Clients;

namespace WaterPoint.Api.Client.Controllers
{
    [RoutePrefix(RouteDefinitions.Clients.Prefix)]
    public class ClientsController : BaseOrgnizationContextController
    {
        private readonly IRequestProcessor<PaginationRequest, IEnumerable<BaseClient>> _listClients;

        public ClientsController(
            IRequestProcessor<PaginationRequest, IEnumerable<BaseClient>> listClients)
        {
            _listClients = listClients;
        }

        public IHttpActionResult Get([FromUri]PaginationRequest paginationRequest)
        {
            //validation

            var result = _listClients.Process(paginationRequest);

            return Ok(result);
        }
    }
}
