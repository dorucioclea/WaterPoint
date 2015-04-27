using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WaterPoint.Core.Domain.Services;

namespace WaterPoint.Api.Controllers
{
    //To be replaced by
    public class TempSecurityContext : ISecurityContext
    {
        public int OrganizationId { get; set; }
        public int StaffId { get; set; }
    }

    public class SuppliersController : ApiController
    {
        private readonly ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [Route(Routes.Suppliers.Get)]
        public async Task<IHttpActionResult> Get()
        {
            var orgId = ControllerContext.RouteData.Values.FirstOrDefault(i => i.Key == "organizationId");

            var result = await _supplierService.ListAsync(Convert.ToInt32(orgId.Value));

            return Ok(result);
        }

        [Route(Routes.Suppliers.GetById)]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var result = await _supplierService.GetByIdAsync(1, id);

            return Ok(result);
        }
    }
}
