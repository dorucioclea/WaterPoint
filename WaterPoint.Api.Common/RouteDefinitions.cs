using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WaterPoint.Api.Common
{
    public class RouteDefinitions
    {
        private const string OrganizationNode = "organizations/{organizationId:int}";

        public class Cusotmers
        {
            public const string Prefix = OrganizationNode + "/customers";
        }

        public class Jobs
        {
            public const string Prefix = OrganizationNode + "/jobs";
        }
    }
}
