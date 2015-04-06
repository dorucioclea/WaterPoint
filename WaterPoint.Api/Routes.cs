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
            public const string Get = "organization/{organizationId:int}/suppliers";

            public const string GetById = "organization/{organizationId:int}/suppliers/{id:int}";
        }
    }
}