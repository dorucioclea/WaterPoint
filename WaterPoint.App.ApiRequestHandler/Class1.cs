using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WaterPoint.App.ApiRequestHandler
{
    public abstract class ProxyHandlerBase : HttpTaskAsyncHandler
    {
        private static readonly IKernel Kernel;
        private static readonly RequestHandlerFactory RequestHandlerFactory;

        static ProxyHandlerBase()
        {
            Kernel = new StandardKernel();

            //RequestHandlerFactory = new Lazy<RequestHandlerFactory>(CreateRequestHandlerFactory);
            RequestHandlerFactory = Kernel.Get<RequestHandlerFactory>();
        }

        public override Task ProcessRequestAsync(HttpContext context)
        {
            var handler = RequestHandlerFactory.Create(context.Request.HttpMethod);

            return handler.HandleRequestAsync(context);
        }
    }
}
