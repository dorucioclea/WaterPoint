using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WaterPoint.Api.Common
{
    public class RouteDefinitions
    {
        private const string OrganizationNode = "organizations/{organizationId:int}";

        public class Organizations
        {
            public const string Prefix = OrganizationNode;
        }

        public class CostItems
        {
            public const string Prefix = OrganizationNode + "/costitems";
        }

        public class Customers
        {
            public const string JobsPrefix = OrganizationNode + "/customers/{customerId:int}/jobs";
            public const string Prefix = OrganizationNode + "/customers";
        }

        public class Jobs
        {
            public const string JobTimesheetPrefix =
                OrganizationNode + "/jobs/{jobId:int}/timesheet";

            public const string CostItemsPrefix = OrganizationNode + "/jobs/{jobId:int}/costitems";

            public const string TasksPrefix = OrganizationNode + "/jobs/{jobId:int}/tasks";

            public const string Prefix = OrganizationNode + "/jobs";
        }

        public class TaskDefinition
        {
            public const string Prefix = OrganizationNode + "/taskdefinitions";
        }

        public class Quotes
        {
            public const string Prefix = OrganizationNode + "/quotes";
        }
    }
}
