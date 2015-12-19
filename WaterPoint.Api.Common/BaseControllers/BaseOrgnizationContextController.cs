using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using Newtonsoft.Json;

namespace WaterPoint.Api.Common.BaseControllers
{
    public class BaseOrgnizationContextController : ApiController
    {
        public OrganizationUserContext OrganizationUser
        {
            get
            {
                var routeData = Request.GetRouteData();

                if(!routeData.Values.ContainsKey("organizationid"))
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

            return users.FirstOrDefault(u => u.OrganizationId == organizationId);
        }
    }

    public class OrganizationUserContext
    {
        public int Id { get; set; }

        public int OrganizationId { get; set; }

        public int OrganizationUserId { get; set; }

        public int OrganizationUserTypeId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsDeleted { get; set; }

        public string Version { get; set; }

        public DateTime UtcCreated { get; set; }

        public DateTime UtcUpdated { get; set; }

        public Guid Uid { get; set; }
    }
}
