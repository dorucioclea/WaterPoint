using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WaterPoint.App.ApiRequestHandler
{
    public class OptionsRequestHandler : RequestHandlerBase
    {
        private static void WriteOptionsResponse(HttpResponse response, HttpStatusCode code, string header, string value)
        {
            response.StatusCode = (int)code;
            response.Headers.Add(header, value);
        }

        protected override void HandleOriginIsRequiredError(HttpContext context, HttpStatusCode code)
        {
            WriteOptionsResponse(context.Response, code, "X-Origin-Required", "true");
        }

        protected override void HandleOriginIsNotAllowedError(HttpContext context, HttpStatusCode code, string origin)
        {
            WriteOptionsResponse(context.Response, code, "X-Requested-Origin", origin);
        }

        protected override Task ApplyHandlingAsync(HttpContext context)
        {
            return Task.FromResult(0);
        }
    }
}
