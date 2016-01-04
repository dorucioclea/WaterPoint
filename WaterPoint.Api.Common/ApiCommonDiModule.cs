using Ninject.Modules;

namespace WaterPoint.Api.Common
{
    public class ApiCommonDiModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPatchEntityAdapter>().To<PatchEntityAdapter>().InSingletonScope();

            Bind<PaginationParameterConverter>().ToSelf();

            Bind<JobStatusQueryParameterConverter>().ToSelf();

            Bind<SimplePaginationParameterConverter>().ToSelf();
        }
    }
}
