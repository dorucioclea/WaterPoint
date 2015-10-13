using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace WaterPoint.App.Controllers
{
    public interface IStaffPrincipal : IPrincipal
    {
        int OrganizationId { get; }
    }

    public class StaffContext : IPrincipal
    {
        public int OrganizationId { get; private set; }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }

        public IIdentity Identity { get; private set; }

        public StaffContext()
        {
            OrganizationId = 1000;
        }
    }

    public abstract class BaseStaffContextController : Controller
    {
        public StaffContext StaffContext
        {
            get { return new StaffContext(); }
        }
    }
}
