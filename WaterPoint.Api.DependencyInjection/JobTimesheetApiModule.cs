using Ninject.Modules;
using WaterPoint.Api.Common;
using WaterPoint.Core.Bll.Commands.JobTimesheet;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.Bll.Queries.JobTimesheet;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Contracts.JobTimesheet;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.JobTimesheet;
using WaterPoint.Core.Domain.Requests.JobTimesheet;
using WaterPoint.Core.RequestProcessor.Timesheet;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.JobTimesheet;


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
            Bind<IQuery<ListJobTimesheet>>().To<ListJobTimesheetQuery>();
            Bind<IQuery<GetJobTimesheet>>().To<GetJobTimesheetQuery>();
        }

        public void BindQueryRunners()
        {
            Bind<IListQueryRunner<ListJobTimesheet, JobTimesheetPoco>>()
                .To<ListQueryRunner<ListJobTimesheet, JobTimesheetPoco>>();

            Bind<IQueryRunner<GetJobTimesheet, JobTimesheet>>()
                .To<QueryRunner<GetJobTimesheet, JobTimesheet>>();
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

            Bind<IRequestProcessor<ListJobTimesheetRequest, SimplePaginatedResult<JobTimesheetBasicContract>>>()
                    .To<ListJobTimesheetProcessor>();

            Bind<IRequestProcessor<GetJobTimesheetRequest, JobTimesheetContract>>()
                .To<GetJobTimesheetProcessor>();
        }
    }
}
