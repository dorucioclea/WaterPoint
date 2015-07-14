using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using WaterPoint.Data.Repository;
using WaterPointSms.Data.Bll;
using WaterPointSms.Data.Service;

namespace WaterPointSms.DependencyInjection
{
    public class SmsDiModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILoginSafeBll>().To<LoginSafeBll>();
            Bind<ILoginSafeRepository>().To<LoginSafeRepository>();
            Bind<ILoginSafeService>().To<LoginSafeService>();
        }
    }
}
