using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WaterPoint.App.Domain.Services;

namespace WaterPoint.App.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }


        public ActionResult Index()
        {
            return View();
        }
    }
}