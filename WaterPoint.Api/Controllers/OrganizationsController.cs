using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WaterPoint.Api.Domain.Services;

namespace WaterPoint.Api.Controllers
{
    public class OrganizationsController : ApiController
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationsController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        //[Route(Routes.Organizations.Get)]
        //public async Task<IHttpActionResult> Get()
        //{
        
        //}

        [Route(Routes.Organizations.GetById)]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var result = await _organizationService.GetByIdAsync(id);

            return Ok(result);
        }
    }
    
}
