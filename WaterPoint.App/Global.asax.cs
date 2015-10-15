using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Ninject;
using WaterPoint.App.DependencyInjection;

namespace WaterPoint.App
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var config = GlobalConfiguration.Configuration;

            WebGlobalConfig.Config(config);

            RegisterDependencyResolver();
        }

        private void RegisterDependencyResolver()
        {
            var kernel = new StandardKernel(new AppDiModule());

            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }

        public class NinjectDependencyResolver : IDependencyResolver
        {
            private readonly IKernel _kernel;

            public NinjectDependencyResolver(IKernel kernel)
            {
                _kernel = kernel;
            }

            public object GetService(Type serviceType)
            {
                return _kernel.TryGet(serviceType);
            }

            public IEnumerable<object> GetServices(Type serviceType)
            {
                try
                {
                    return _kernel.GetAll(serviceType);
                }
                catch (Exception)
                {
                    return new List<object>();
                }
            }
        }

        public class JsonCamelCaseResolver : CamelCasePropertyNamesContractResolver
        {
            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                var res = base.CreateProperty(member, memberSerialization);

                var attrs = member
                    .GetCustomAttributes(typeof(JsonPropertyAttribute), true);

                if (!attrs.Any())
                    return res;

                var attr = (attrs[0] as JsonPropertyAttribute);

                if (res.PropertyName != null)
                    res.PropertyName = attr.PropertyName;

                return res;
            }
        }
    }
}
