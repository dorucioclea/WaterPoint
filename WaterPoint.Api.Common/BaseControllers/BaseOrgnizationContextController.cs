using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using Newtonsoft.Json;
using WaterPoint.Core.Domain.Exceptions;

namespace WaterPoint.Api.Common.BaseControllers
{
    public class BaseOrgnizationContextController : ApiController
    {
        public OrganizationUserContext OrganizationUser
        {
            get
            {
                var routeData = Request.GetRouteData();

                if (!routeData.Values.ContainsKey("organizationid"))
                    throw new InvalidOperationException("没有 organization");

                var organizationId = routeData.Values["organizationId"];

                return GetCurrentOrganizationUser(Convert.ToInt32(organizationId));
            }
        }

        private OrganizationUserContext GetCurrentOrganizationUser(int organizationId)
        {
            var context = Request.GetOwinContext();

            var user = context.Authentication.User;

            var userContextData = user.Claims.First(i => i.Type == ClaimTypes.PrimaryGroupSid).Value;

            var users = JsonConvert.DeserializeObject<IEnumerable<OrganizationUserContext>>(userContextData);

            var orgUser = users.FirstOrDefault(u => u.OrganizationId == organizationId);

            if (orgUser == null)
                throw new InvalidOrganizationContextException();

            return orgUser;
        }
    }
}
