using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WaterPoint.Api
{
    public class Routes
    {
        public class Suppliers
        {
            public const string Get = "organizations/{organizationId:int}/suppliers";

            public const string GetById = "organizations/{organizationId:int}/suppliers/{id:int}";
        }

        public class Organizations
        {
            public const string GetById = "organizations/{id:int}";
        }
    }
}