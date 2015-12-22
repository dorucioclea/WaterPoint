using System.Collections.Generic;
using Ninject.Modules;
using WaterPoint.Core.Bll.Commands.JobTasks;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.Bll.Queries.Jobs;
using WaterPoint.Core.Bll.Queries.JobTasks;
using WaterPoint.Core.Bll.QueryParameters.JobTasks;
using WaterPoint.Core.Bll.QueryParameters.TaskDefinitions;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Bll.QueryRunners.Jobs;
using WaterPoint.Core.Bll.QueryRunners.JobTasks;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Contracts.TaskDefinitions;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Dtos.Requests.Jobs;
using WaterPoint.Core.Domain.Dtos.Requests.Shared;
using WaterPoint.Core.Domain.Dtos.Requests.TaskDefinitions;
using WaterPoint.Core.RequestProcessor;
using WaterPoint.Core.RequestProcessor.Jobs;
using WaterPoint.Core.RequestProcessor.TaskDefinitions;
using WaterPoint.Data.DbContext.Dapper;
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
        }

        public void BindQueryRunners()
        {
            Bind<IQueryRunner<GetJobTask, JobTask>>().To<GetJobTaskRunner>();
        }

        public void BindCommands()
        {

            Bind<ICommand<CreateJobTask>>().To<CreateJobTaskCommand>();
        }

        public void BindCommandExecutors()
        {

            Bind<ICommandExecutor<CreateTaskDefinition>>().To<CreateCommandExecutor<CreateTaskDefinition>>();
        }

        private void BindRequestProcessors()
        {
            Bind<IRequestProcessor<CreateTaskDefinitionRequest, TaskDefinitionContract>>()
                .To<CreateTaskDefinitionProcessor>();
        }
    }
}
