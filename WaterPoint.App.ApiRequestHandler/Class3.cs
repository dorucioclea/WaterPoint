using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WaterPoint.App.ApiRequestHandler
{
    public static class CrossOriginPolicy
    {
        private static readonly ApiV2ProxySection ProxyHandlerConfig;

        static CrossOriginPolicy()
        {
            ProxyHandlerConfig = (ApiV2ProxySection)ConfigurationManager.GetSection("apiV2Proxy");
        }

        public static bool RequireOriginHeader
        {
            get { return ProxyHandlerConfig.AllowedOrigins.RequireOrigin; }
        }

        public static bool IsOriginAllowed(string origin)
        {
            if (String.IsNullOrWhiteSpace(origin) && RequireOriginHeader)
                return false;

            return
                ProxyHandlerConfig.AllowedOrigins.AllowAll ||
                ProxyHandlerConfig.AllowedOrigins.ContainsOrigin(origin);
        }

        public static bool IsOriginAllowed(HttpRequest request)
        {
            return IsOriginAllowed(request.Headers["Origin"]);
        }

        public static void ApplyOriginPolicy(HttpRequest request, HttpResponse response)
        {
            const string allowOriginHeaderName = "Access-Control-Allow-Origin";
            const string allowHeadersHeaderName = "Access-Control-Allow-Headers";
            const string allowMethodsHeaderName = "Access-Control-Allow-Methods";
            const string allowCredentialsHeaderName = "Access-Control-Allow-Credentials";
            const string accessControlMaxAge = "Access-Control-Max-Age";

            response.Headers.Remove(allowOriginHeaderName);
            response.Headers.Remove(allowHeadersHeaderName);
            response.Headers.Remove(allowMethodsHeaderName);
            response.Headers.Remove(allowCredentialsHeaderName);
            response.Headers.Remove(accessControlMaxAge);

            var origin = request.Headers["Origin"];
            if (origin == null)
                return;

            var isOptionRequest = string.Equals(request.HttpMethod, "OPTIONS", StringComparison.OrdinalIgnoreCase);

            if (isOptionRequest)
            {
                const string requestHeadersHeaderName = "Access-Control-Request-Headers";
                const string requestMethodHeaderName = "Access-Control-Request-Method";

                var maxAge = ProxyHandlerConfig.AllowedOrigins.AccessControlMaxAge.ToString(CultureInfo.InvariantCulture);

                response.Headers.Add(allowHeadersHeaderName, request.Headers[requestHeadersHeaderName]);
                response.Headers.Add(allowMethodsHeaderName, request.Headers[requestMethodHeaderName]);
                response.Headers.Add(accessControlMaxAge, maxAge);
            }

            response.Headers.Add(allowOriginHeaderName, origin);
            response.Headers.Add(allowCredentialsHeaderName, "true");
        }
    }
}
