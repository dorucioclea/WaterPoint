using System.Web.Http;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.OAuth;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using WaterPoint.Api.Common.AppStart;
using WaterPoint.Core.DependencyInjection;

namespace WaterPoint.Api.Common
{
    public abstract class CommonStartup
    {
        public virtual void Configuration(IAppBuilder app)
        {
            var kernel = CreateKernel();

            ConfigureAuth(app, kernel);

            var config = ConfigureWebApi();

            ConfigNinjectForWebApi(app, kernel, config);
        }

        public virtual IKernel CreateKernel()
        {
            var kernel = new StandardKernel(new CoreDiModule());

            kernel.Load(new ApiCommonDiModule());

            return kernel;
        }

        public virtual void ConfigureAuth(IAppBuilder app, IKernel kernel)
        {
            //TODO: abstract this out to a common place
            var oauthbeareroptions = new OAuthBearerAuthenticationOptions
            {
                AccessTokenFormat =
                    new TicketDataFormat(app.CreateDataProtector(typeof(OAuthAuthorizationServerMiddleware).Namespace, "access_token", "v1"))
            };

            app.UseOAuthBearerAuthentication(oauthbeareroptions);
        }

        public virtual HttpConfiguration ConfigureWebApi()
        {
            var config = new HttpConfiguration();

            WebApiConfig.Register(config);

            return config;
        }

        public virtual void ConfigNinjectForWebApi(IAppBuilder app, IKernel kernel, HttpConfiguration config)
        {
            app.UseNinjectMiddleware(() => kernel)
                .UseNinjectWebApi(config);
        }
    }
}
