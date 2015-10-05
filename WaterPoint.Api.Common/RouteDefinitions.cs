using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WaterPoint.Api.Common
{
    public class RouteDefinitions
    {
        private const string OrganizationNode = "organizations/{OrganizationId:int}";

        public class Cusotmers
        {
            public const string Prefix = OrganizationNode + "/customers";
        }

        public class Flags
        {
            public const string Prefix = OrganizationNode + "/flags";

            public const string GetProducts = "{flagId:int}/products";
        }

        //public class Banners
        //{
        //    public const string Prefix = OrganizationNode + "/bannertypes";

        //    public const string GetBanners = "{bannerTypeId:int}/banners";
        //}
    }
}
