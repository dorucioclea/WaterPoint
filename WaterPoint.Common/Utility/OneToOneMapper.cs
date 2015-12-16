using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class OneToOneMapperExtensions
    {
        public static TOutput MapTo<TInput, TOutput>(this TInput source, TOutput output)
            where TInput : class
        {
            var inputProperties = typeof(TInput).GetProperties();

            var outputProperties = typeof(TOutput).GetProperties();

            foreach (var property in inputProperties)
            {
                var outputProperty = outputProperties.FirstOrDefault(i =>
                    string.Equals(i.Name, property.Name, StringComparison.CurrentCultureIgnoreCase));

                if (outputProperty == null)
                    continue;

                var value = property.GetValue(source);

                outputProperty.SetValue(output, value, null);
            }

            return output;
        }
    }
}
