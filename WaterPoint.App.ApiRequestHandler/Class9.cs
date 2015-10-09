using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WaterPoint.App.ApiRequestHandler
{
    public class ApiRequestHandler : RequestHandlerBase
    {
        private readonly CredentialAuthManagerBase _credentialAuthManager;
        private readonly IRequestRewriter _requestRewriter;

        public ApiRequestHandler(
            CredentialAuthManagerBase credentialAuthManager,
            IRequestRewriter requestRewriter)
        {
            if (credentialAuthManager == null)
                throw new ArgumentNullException("credentialAuthManager");

            if (requestRewriter == null)
                throw new ArgumentNullException("requestRewriter");

            _credentialAuthManager = credentialAuthManager;
            _requestRewriter = requestRewriter;
        }

        private static void WriteResponse(HttpResponse response, HttpStatusCode code, string message)
        {
            response.StatusCode = (int)code;
            response.ContentType = ProblemJson.ContentType;
            response.Write(new ErrorContract((int)code, message).ToJson());
        }

        protected override void HandleOriginIsRequiredError(HttpContext context, HttpStatusCode code)
        {
            WriteResponse(context.Response, HttpStatusCode.BadRequest, "Origin is required");
        }

        protected override void HandleOriginIsNotAllowedError(HttpContext context, HttpStatusCode code, string origin)
        {
            WriteResponse(
                context.Response,
                HttpStatusCode.Forbidden,
                String.Format("Origin {0} is not allowed", origin));
        }

        protected override async Task ApplyHandlingAsync(HttpContext context)
        {
            if (!_credentialAuthManager.IsAuthorized(context))
            {
                WriteResponse(
                    context.Response,
                    HttpStatusCode.Unauthorized,
                    "Couldn't validate authentication cookie");
                context.Response.SuppressFormsAuthenticationRedirect = true;
                return;
            }

            var userInfo = _credentialAuthManager.GetUserInfo(context);

            await _requestRewriter.RewriteAsync(context.Request, userInfo, context.Response);
        }
    }
}
