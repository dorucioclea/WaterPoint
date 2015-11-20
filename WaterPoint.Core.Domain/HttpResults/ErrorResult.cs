using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using WaterPoint.Core.Domain.Contracts;

namespace WaterPoint.Core.Domain.HttpResults
{
    public class ErrorResult : IHttpActionResult
    {
        public HttpStatusCode Status { get; private set; }

        public string Message { get; private set; }

        public IList<ErrorDetailContract> Errors { get; private set; }

        private readonly ApiController _controller;
        //private readonly HttpRequestMessage _request;
        private readonly HttpConfiguration _configuration;

        public ErrorResult(HttpStatusCode code, string message, ApiController controller)
        {
            Status = code;
            Message = message;
            Errors = new List<ErrorDetailContract>();
            _controller = controller;
            _configuration = controller.Configuration;
        }

        public void AddError(string detailMessage, string detailLink)
        {
            Errors.Add(new ErrorDetailContract { Message = detailMessage, DetailLink = detailLink });
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var errorContract = new ErrorContract
            {
                Message = Message,
                Errors = Errors
            };

            var problemHeader = new MediaTypeHeaderValue("application/api-problem+json");

            var result = new FormattedContentResult<ErrorContract>(
                    Status,
                    errorContract,
                    _configuration.Formatters.JsonFormatter,
                    problemHeader,
                    _controller);

            //var contentResult = _controller != null
            //    ? new FormattedContentResult<ErrorContract>(
            //        Status, errorContract, _configuration.Formatters.JsonFormatter, problemHeader, _controller)
            //    : new FormattedContentResult<ErrorContract>(
            //        Status, errorContract, _configuration.Formatters.JsonFormatter, problemHeader, _request);

            return result.ExecuteAsync(cancellationToken);
        }
    }
}
