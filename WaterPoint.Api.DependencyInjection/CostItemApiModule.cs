using Ninject.Modules;
using WaterPoint.Core.RequestProcessor;

namespace WaterPoint.Api.DependencyInjection
{
    public class CostItemApiModule : NinjectModule
    {
        public override void Load()
        {
            BindRequestProcessors();
            BindQueries();
            BindQueryRunners();
            BindCommands();
            BindCommandExecutors();
            Bind<PaginationQueryParameterConverter>().ToSelf();
        }

        private void BindQueries()
        {
        }

        public void BindQueryRunners()
        {
        }

        public void BindCommands()
        {
        }

        public void BindCommandExecutors()
        {
        }

        private void BindRequestProcessors()
        {

        }
    }
}
