using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.App.ApiRequestHandler
{
    public class ApiV2ProxySection : ConfigurationSection
    {
        private const string AllowedOriginsPropertyName = "allowedOrigins";

        [ConfigurationProperty(AllowedOriginsPropertyName, IsRequired = true)]
        public AllowedOriginElementsCollection AllowedOrigins
        {
            get { return (AllowedOriginElementsCollection)base[AllowedOriginsPropertyName]; }
        }
    }
}
