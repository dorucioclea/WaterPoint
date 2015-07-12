using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using WaterPoint.App.DataProvider;
using WaterPoint.App.Domain.Services;
using WaterPoint.App.Service;
using WaterPoint.Core.ApiClient;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.DataProvider;

namespace WaterPoint.Core.DependencyInjection
{
    public class AppDiModule : NinjectModule
    {
        public override void Load()
        {
            BindServices();
            BindDataProvider();
            BindApiClient();
        }

        private void BindApiClient()
        {
            Bind<IApiClient>().To<ApiClient.ApiClient>();
            Bind<IApiContext>().To<ApiContext>().WithConstructorArgument(new Uri("http://localhost/WaterPoint.Api"));
        }

        private void BindDataProvider()
        {
            Bind<IRestaurantApiDataProvider>().To<RestaurantApiDataProvider>();
        }

        private void BindServices()
        {
            Bind<IRestaurantService>().To<RestaurantService>();
        }
    }
}
