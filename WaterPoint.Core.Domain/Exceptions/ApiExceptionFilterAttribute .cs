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
                var exception = context.Exception as InvalidInputDataException;

                result = new ErrorResult(HttpStatusCode.BadRequest, context.Exception.Message, apicontroller);

                foreach (var exp in exception.Messages)
                    result.AddError(exp, null);

                context.Response = await result.ExecuteAsync(cancellationToken);
            }


            if (result == null)
            {
                result = new ErrorResult(HttpStatusCode.InternalServerError, context.Exception.Message, apicontroller);

                //TODO: add internal server error message instead of the .net one.
                result.AddError(context.Exception.ToString(), null);

                context.Response = await result.ExecuteAsync(cancellationToken);
            }
        }
    }
}

