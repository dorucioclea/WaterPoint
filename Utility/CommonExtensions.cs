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
            var dictionary = new Dictionary<string, object>();

            var properties = source.GetType().GetProperties();

            foreach (var pro in properties)
            {
                dictionary.Add(pro.Name, pro.GetValue(source));
            }

            return dictionary;
        }
    }
}
