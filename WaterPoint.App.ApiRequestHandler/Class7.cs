using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.App.ApiRequestHandler
{
    public class RequestHandlerFactory
    {
        private readonly RequestHandlerBase _optionsHandler;
        private readonly RequestHandlerBase _apiHandler;

        public RequestHandlerFactory(RequestHandlerBase optionsHandler, RequestHandlerBase apiHandler)
        {
            if (optionsHandler == null)
                throw new ArgumentNullException("optionsHandler");

            if (apiHandler == null)
                throw new ArgumentNullException("apiHandler");

            _optionsHandler = optionsHandler;
            _apiHandler = apiHandler;
        }

        public RequestHandlerBase Create(string httpMethod)
        {
            if (httpMethod == null)
                throw new ArgumentNullException("httpMethod");

            switch (httpMethod.ToUpper())
            {
                case "OPTIONS":
                    return _optionsHandler;
                default:
                    return _apiHandler;
            }
        }
    }
}
