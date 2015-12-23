﻿using System;
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
            public const string JobsPrefix = OrganizationNode + "/customers/{customerId:int}/jobs";
            public const string Prefix = OrganizationNode + "/customers";
        }

        public class Jobs
        {
            public const string TasksPrefix = OrganizationNode + "/jobs/{jobId:int}/tasks";

            public const string Prefix = OrganizationNode + "/jobs";
        }

        public class TaskDefinition
        {
            public const string Prefix = OrganizationNode + "/taskdefinitions";
        }
    }
}
