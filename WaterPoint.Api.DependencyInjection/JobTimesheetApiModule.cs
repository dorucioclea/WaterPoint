using Ninject.Modules;
using WaterPoint.Api.Common;
using WaterPoint.Core.Bll.Commands.JobTimesheet;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.JobTimesheet;
using WaterPoint.Core.Domain.Requests.JobTimesheet;
using WaterPoint.Core.RequestProcessor.Timesheet;


namespace WaterPoint.Api.DependencyInjection
{
    public class JobTimesheetApiModule : NinjectModule
    {
        public override void Load()
        {
            BindRequestProcessors();
            BindQueries();
            BindQueryRunners();
            BindCommands();
            BindCommandExecutors();

            Bind<JobTimesheetAnalyzer>().ToSelf().InSingletonScope();
        }

        private void BindQueries()
        {
        }

        public void BindQueryRunners()
        {

        }

        public void BindCommands()
        {
            Bind<ICommand<CreateJobTimesheet>>().To<CreateJobTimesheetCommand>();
        }

        public void BindCommandExecutors()
        {
            Bind<ICommandExecutor<CreateJobTimesheet>>().To<CreateCommandExecutor<CreateJobTimesheet>>();
        }

        private void BindRequestProcessors()
        {
            Bind<IRequestProcessor<CreateJobTimesheetRequest, CommandResultContract>>()
                    .To<CreateJobTimesheetProcessor>();
        }
    }
}
