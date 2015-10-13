using System;
using System.Configuration;

namespace WaterPoint.App.Domain
{
    public static class AppSettings
    {
        public static string ApiDomain
        {
            get
            {
                var apiDomain = ConfigurationManager.AppSettings["waterpoint.api.domain"];

                return apiDomain;
            }
        }
    }

    public partial class ApiV1
    {
        private static readonly string ApiV1Node = string.Join("/", AppSettings.ApiDomain, "{0}-api-v1");

        private const string OrganizationNode = "organizations/{0}";

        public class Customers
        {
            private static readonly string MainNode = string.Format(ApiV1Node, "customer");

            private static readonly string PaginatedList = string.Join("/", MainNode, OrganizationNode, "customers");

            public static Uri List(int organizationId)
            {
                return new Uri(string.Format(PaginatedList, organizationId));
            }
        }
    }
}
