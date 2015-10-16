using System.Threading.Tasks;
using System.Web.Mvc;
using WaterPoint.App.Controllers;
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
