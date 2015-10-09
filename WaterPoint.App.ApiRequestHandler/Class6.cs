using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.App.ApiRequestHandler
{
    public class AllowedOriginElement : ConfigurationElement
    {
        private const string OriginPropertyName = "origin";

        [ConfigurationProperty(OriginPropertyName, IsKey = true, IsRequired = true)]
        public string Origin
        {
            get { return (string)base[OriginPropertyName]; }
            set { base[OriginPropertyName] = value; }
        }
    }
}
