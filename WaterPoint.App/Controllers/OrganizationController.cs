using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WaterPoint.App.ApiClient;

namespace WaterPoint.App.Controllers
{
    public class OrganizationController : Controller
    {
        // GET: Organization
        public ActionResult Index()
        {
            return View();
        }
    }
}