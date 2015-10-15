using System.Globalization;
using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace WaterPoint.App
{
    public class WebGlobalConfig
    {
        public static void Config(HttpConfiguration routes)
        {
            var culture = CultureInfo.InvariantCulture;

            var jsonFormatter = new JsonMediaTypeFormatter
            {
                SerializerSettings =
                {
                    ContractResolver = new MvcApplication.JsonCamelCaseResolver(),
                    Culture = culture,
                    DateFormatString = culture.DateTimeFormat.SortableDateTimePattern,
                    DateParseHandling = DateParseHandling.None,
                }
            };

            jsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter { CamelCaseText = true });
        }
    }
}
