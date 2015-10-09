using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WaterPoint.App.ApiRequestHandler
{
    public abstract class RequestHandlerBase
    {
        protected abstract void HandleOriginIsRequiredError(HttpContext context, HttpStatusCode code);

        protected abstract void HandleOriginIsNotAllowedError(HttpContext context, HttpStatusCode code, string origin);

        protected abstract Task ApplyHandlingAsync(HttpContext context);

        public virtual async Task HandleRequestAsync(HttpContext context)
        {
            var origin = context.Request.Headers["Origin"];
            if (String.IsNullOrWhiteSpace(origin) && CrossOriginPolicy.RequireOriginHeader)
            {
                HandleOriginIsRequiredError(context, HttpStatusCode.BadRequest);
                return;
            }

            if (!CrossOriginPolicy.IsOriginAllowed(context.Request))
            {
                HandleOriginIsNotAllowedError(context, HttpStatusCode.Forbidden, origin);
                return;
            }

            await ApplyHandlingAsync(context);

            CrossOriginPolicy.ApplyOriginPolicy(context.Request, context.Response);
        }
    }
}
