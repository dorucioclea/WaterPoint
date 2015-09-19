using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WaterPoint.Api
{
    public class RouteDefinitions
    {
        private const string ShopNode = "shops/{shopId:int}";

        public class Flags
        {
            public const string Prefix = ShopNode + "/flags";

            public const string GetProducts = "{flagId:int}/products";
        }

        public class Banners
        {
            public const string Prefix = ShopNode + "/bannertypes";

            public const string GetBanners = "{bannerTypeId:int}/banners";
        }
    }
}