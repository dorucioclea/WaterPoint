using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;
using WaterPoint.Core.Domain.HttpResults;

namespace WaterPoint.Core.Domain.Exceptions
{
    public class ApiExceptionHandlerFilterAttribute : ExceptionFilterAttribute
    {
        public override async Task OnExceptionAsync(HttpActionExecutedContext context, CancellationToken cancellationToken)
        {
            var apicontroller = context.ActionContext.ControllerContext.Controller as ApiController;

            ErrorResult result = null;

            if (context.Exception is InvalidInputDataException)
            {
                result = new ErrorResult(HttpStatusCode.BadRequest, context.Exception.Message, apicontroller);

                context.Response = await result.ExecuteAsync(cancellationToken);
            }


            if (result == null)
            {
                result = new ErrorResult(HttpStatusCode.InternalServerError, context.Exception.Message, apicontroller);

                result.AddError(context.Exception.ToString(), null);

                context.Response = await result.ExecuteAsync(cancellationToken);
            }
        }
    }
}

