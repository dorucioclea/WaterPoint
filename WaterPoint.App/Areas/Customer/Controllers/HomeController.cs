using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WaterPoint.App.Controllers;
using WaterPoint.App.Domain.ApiContracts;
using WaterPoint.App.Service.Customer;

namespace WaterPoint.App.Areas.Customer.Controllers
{
    public class HomeController : BaseStaffContextController
    {
        private readonly ICustomerService _customerService;

        public HomeController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<ActionResult> Index()
        {
            var result = await _customerService.GetCustomerHomeIndex(StaffContext.OrganizationId);

            return View(result);
        }
    }
}
