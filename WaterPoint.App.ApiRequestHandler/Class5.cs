using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.App.ApiRequestHandler
{
    [ConfigurationCollection(typeof(AllowedOriginElement),
        AddItemName = "add",
        ClearItemsName = "clear",
        RemoveItemName = "remove")]
    public class AllowedOriginElementsCollection : ConfigurationElementCollection
    {
        private const string AllowAllPropertyName = "allowAll";
        private const string RequireOriginHeaderPropertyName = "requireOriginHeader";
        private const string AccessControlMaxAgePropertyName = "accessControlMaxAge";

        [ConfigurationProperty(AllowAllPropertyName, DefaultValue = false)]
        public bool AllowAll
        {
            get { return (bool)base[AllowAllPropertyName]; }
            set { base[AllowAllPropertyName] = value; }
        }

        [ConfigurationProperty(RequireOriginHeaderPropertyName, DefaultValue = false)]
        public bool RequireOrigin
        {
            get { return (bool)base[RequireOriginHeaderPropertyName]; }
            set { base[RequireOriginHeaderPropertyName] = value; }
        }

        [ConfigurationProperty(AccessControlMaxAgePropertyName, DefaultValue = 18 * 60 * 60)]
        public int AccessControlMaxAge
        {
            get { return (int)base[AccessControlMaxAgePropertyName]; }
            set { base[AccessControlMaxAgePropertyName] = value; }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new AllowedOriginElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            var allowedOrigin = (AllowedOriginElement)element;

            return allowedOrigin.Origin.ToLower();
        }

        public bool ContainsOrigin(string origin)
        {
            if (origin == null)
                return false;

            return BaseGet(origin.ToLower()) != null;
        }
    }
}
