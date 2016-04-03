using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using WaterPoint.Core.Domain.HttpResults;

namespace WaterPoint.Api.Common.HttpActionResults
{
    public class BadRequestWithErrorsResult : ErrorResult
    {
        public BadRequestWithErrorsResult(ModelStateDictionary modelState, ApiController controller)
            : base(HttpStatusCode.BadRequest, "invalid request", controller)
        {
            var errors = modelState.Where(i => i.Value.Errors.Count > 0).SelectMany(i => i.Value.Errors);

            foreach (var modelError in errors)
            {
                AddError(modelError.ErrorMessage, modelError.Exception.ToString());
            }
        }
    }
}
