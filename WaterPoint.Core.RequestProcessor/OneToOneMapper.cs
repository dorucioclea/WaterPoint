using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Core.RequestProcessor
{
    public static class OneToOneMapper
    {
        public static TOutput MapFrom<TOutput>(object obj)
            where TOutput : class,
                new()
        {
            var inputProperties = obj.GetType().GetProperties();

            var outputProperties = typeof(TOutput).GetProperties();

            var output = new TOutput();

            foreach (var property in inputProperties)
            {
                var outputProperty = outputProperties.FirstOrDefault(i =>
                    string.Equals(i.Name, property.Name, StringComparison.CurrentCultureIgnoreCase));

                if (outputProperty == null)
                    continue;

                var value = property.GetValue(obj);

                outputProperty.SetValue(output, value, null);
            }

            return output;
        }
    }
}
