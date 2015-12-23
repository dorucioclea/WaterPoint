using Ninject.Modules;
using WaterPoint.Core.Bll.Commands.JobTasks;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.Bll.Queries.JobTasks;
using WaterPoint.Core.Bll.QueryParameters.JobTasks;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Bll.QueryRunners.JobTasks;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Contracts.JobTasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Dtos.Requests.JobTasks;
using WaterPoint.Core.RequestProcessor.JobTasks;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Api.DependencyInjection
{
    public class JobTaskApiModule : NinjectModule
    {
        public override void Load()
        {
            BindRequestProcessors();
            BindQueries();
            BindQueryRunners();
            BindCommands();
        }

        private void BindQueries()
        {
            Bind<IQuery<GetJobTask>>().To<GetJobTaskQuery>();
            Bind<IQuery<ListJobTasks>>().To<ListJobTasksQuery>();
        }

        public void BindQueryRunners()
        {
            Bind<IQueryRunner<GetJobTask, JobTask>>().To<GetJobTaskRunner>();
            Bind<IListEntitiesRunner<ListJobTasks, JobTask>>().To<ListJobTasksRunner>();
        }

        public void BindCommands()
        {
            Bind<ICommand<CreateJobTask>>().To<CreateJobTaskCommand>();
            Bind<ICommand<UpdateJobTask>>().To<UpdateJobTaskCommand>();
        }

        public void BindCommandExecutors()
        {
            Bind<ICommandExecutor<CreateJobTask>>().To<CreateCommandExecutor<CreateJobTask>>();
            Bind<ICommandExecutor<UpdateJobTask>>().To<UpdateCommandExecutor<UpdateJobTask>>();
        }

        private void BindRequestProcessors()
        {
            Bind<IRequestProcessor<GetJobTaskByIdRequest, JobTaskContract>>()
                .To<GetJobTaskProcessor>();

            Bind<IRequestProcessor<UpdateJobTaskRequest, CommandResultContract>>()
                .To<UpdateJobTaskProcessor>();

            Bind<IRequestProcessor<CreateJobTaskRequest, CommandResultContract>>()
                .To<CreateJobTaskRequestProcessor>();

            Bind<IRequestProcessor<ListJobTasksRequest, PaginatedResult<JobTaskContract>>>()
                .To<ListJobTasksProcessor>();
        }
    }
}
