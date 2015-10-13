using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using WaterPoint.ApiClient;
using WaterPoint.App.Service.Customer;
using WaterPoint.App.ViewModelMapper;

namespace WaterPoint.App.DependencyInjection
{
    public class AppDiModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IApiClient>().To<ApiClientHandler>();
            Bind<ICustomerService>().To<CustomerService>();
            Bind<IApiContractToViewModelMapper>().To<ApiContractToViewModelMapper>();

            //Bind<IRequestProcessor<ListBannersByBannerTypeRequest, IEnumerable<BasicBanner>>>()
            //    .To<ListBannersByBannerTypeProcessor>();
        }
    }
}
