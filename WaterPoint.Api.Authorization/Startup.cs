using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using WaterPoint.Api.Common;

[assembly: OwinStartup(typeof(WaterPoint.Api.Authorization.Startup))]

namespace WaterPoint.Api.Authorization
{
    public partial class Startup : CommonStartup
    {
        public override void Configuration(IAppBuilder app)
        {
            base.Configuration(app);

            ConfigureAuth(app);
        }
    }
}
