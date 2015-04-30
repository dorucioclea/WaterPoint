using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class CommonExtensions
    {
        public static IDictionary<string, object> ToDictionary(this object source)
        {
            var properties = source.GetType().GetProperties();

            return properties.ToDictionary(pro => pro.Name, pro => pro.GetValue(source));
        }
    }
}
