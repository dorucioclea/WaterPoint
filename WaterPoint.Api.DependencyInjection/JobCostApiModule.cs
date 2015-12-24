using Ninject.Modules;
using WaterPoint.Core.Bll.Commands.Jobs;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Jobs;
using WaterPoint.Core.Domain.Requests.Jobs;
using WaterPoint.Core.RequestProcessor.Jobs;

namespace WaterPoint.Api.DependencyInjection
{
    public class JobCostApiModule : NinjectModule
    {
        public override void Load()
        {
            BindRequestProcessors();
            BindQueries();
            BindQueryRunners();
            BindCommands();
            BindCommandExecutors();

        }

        private void BindQueries()
        {

        }

        public void BindQueryRunners()
        {
        }

        public void BindCommands()
        {
            Bind<ICommand<CreateJobCostItem>>().To<CreateJobCostItemCommand>();
        }

        public void BindCommandExecutors()
        {
            Bind<ICommandExecutor<CreateJobCostItem>>().To<CreateCommandExecutor<CreateJobCostItem>>();
        }

        private void BindRequestProcessors()
        {
            Bind<IRequestProcessor<CreateJobCostItemRequest, JobCostItemContract>>()
                .To<CreateJobCostItemProcessor>();
        }
    }
}
