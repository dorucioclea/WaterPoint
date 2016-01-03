using Ninject.Modules;
using WaterPoint.Core.Bll.Commands.TaskDefinitions;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.Bll.Queries.TaskDefinitions;
using WaterPoint.Core.Domain.QueryParameters.Shared;
using WaterPoint.Core.Domain.QueryParameters.TaskDefinitions;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Contracts.TaskDefinitions;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Requests.Shared;
using WaterPoint.Core.Domain.Requests.TaskDefinitions;
using WaterPoint.Core.RequestProcessor;
using WaterPoint.Core.RequestProcessor.TaskDefinitions;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Api.DependencyInjection
{
    public class TaskDefinitionApiModule : NinjectModule
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
            Bind<IQuery<GetTaskDefinition>>().To<GetTaskDefinitionQuery>();

            Bind<IQuery<PaginatedOrgId>>().To<ListTaskDefinitionsQuery>();
        }

        public void BindQueryRunners()
        {
            Bind<IQueryRunner<GetTaskDefinition, TaskDefinition>>()
                .To<QueryRunner<GetTaskDefinition, TaskDefinition>>();

            Bind<IListQueryRunner<PaginatedOrgId, TaskDefinition>>()
                .To<ListQueryRunner<PaginatedOrgId, TaskDefinition>>();
        }

        public void BindCommands()
        {
            Bind<ICommand<CreateTaskDefinition>>().To<CreateTaskDefinitionCommand>();
            Bind<ICommand<UpdateTaskDefinition>>().To<UpdateTaskDefinitionCommand>();
        }

        public void BindCommandExecutors()
        {
            Bind<ICommandExecutor<CreateTaskDefinition>>().To<CreateCommandExecutor<CreateTaskDefinition>>();
            Bind<ICommandExecutor<UpdateTaskDefinition>>().To<UpdateCommandExecutor<UpdateTaskDefinition>>();
        }

        private void BindRequestProcessors()
        {
            Bind<IWriteRequestProcessor<CreateTaskDefinitionRequest>>()
                .To<CreateTaskDefinitionProcessor>();

            Bind<IRequestProcessor<GetTaskDefinitionByIdRequest, TaskDefinitionContract>>()
                .To<GetTaskDefinitionByIdRequestProcessor>();

            Bind<IPaginatedProcessor<ListWithOrgIdRequest, TaskDefinitionContract>>()
                .To<ListTaskDefinitionsProcessor>();

            Bind<IWriteRequestProcessor<UpdateTaskDefinitionRequest>>()
                .To<UpdateTaskDefinitionProcessor>();
        }
    }
}
