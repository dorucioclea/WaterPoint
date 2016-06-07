using System;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using WaterPoint.Api.Common.BaseControllers;

namespace WaterPoint.Api.Common.Attributes
{
    public class RequirePrivilegesAttribute : ActionFilterAttribute
    {
        private readonly Privileges[] _requiredPrivilegeses;

        public RequirePrivilegesAttribute(Privileges[] requiredPrivilegeses)
        {
            _requiredPrivilegeses = requiredPrivilegeses;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var controller = actionContext.ControllerContext.Controller as BaseOrgnizationContextController;

            if (controller == null)
                throw new InvalidCastException("RequirePrivilegesAttribute can only be used for BaseOrgnizationContextController");

            var userPrivileges = controller.Credential.Privileges.Select(i => i.Id);

            var isLegit = _requiredPrivilegeses.All(i => userPrivileges.Contains((int)i));

            if (!isLegit)
                throw new UnauthorizedAccessException("isLegit");

            base.OnActionExecuting(actionContext);
        }
    }
}
