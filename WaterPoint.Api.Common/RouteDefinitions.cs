using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WaterPoint.Api.Common
{
    public class RouteDefinitions
    {
        private const string OrganizationNode = "organizations/{organizationId:int}";

        public class CostItems
        {
            public const string Prefix = OrganizationNode + "/costitems";
        }

        public class Customers
        {
            public const string Prefix = OrganizationNode + "/customers";
            public const string Jobs = "{customerId:int}/jobs";
        }

        public class Jobs
        {
            public const string Tasks = OrganizationNode + "{jobId:int}/tasks";

            public const string GetTask = OrganizationNode + "{jobId:int}/tasks/{id:int}";

            public const string Prefix = OrganizationNode + "/jobs";
        }

        public class TaskDefinition
        {
            public const string Prefix = OrganizationNode + "/taskdefinitions";
        }
    }
}
