using System.Collections.Generic;
using System.Windows.Input;
using Ninject.Modules;
using WaterPoint.Core.Bll.Commands.TaskDefinitions;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.Bll.Queries.Jobs;
using WaterPoint.Core.Bll.Queries.TaskDefinitions;
using WaterPoint.Core.Bll.QueryParameters.TaskDefinitions;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Bll.QueryRunners.Jobs;
using WaterPoint.Core.Bll.QueryRunners.TaskDefinitions;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Contracts.TaskDefinitions;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Dtos.Requests.Jobs;
using WaterPoint.Core.Domain.Dtos.Requests.Shared;
using WaterPoint.Core.Domain.Dtos.Requests.TaskDefinitions;
using WaterPoint.Core.RequestProcessor;
using WaterPoint.Core.RequestProcessor.Customers;
using WaterPoint.Core.RequestProcessor.Jobs;
using WaterPoint.Core.RequestProcessor.TaskDefinitions;
using WaterPoint.Data.DbContext.Dapper;
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
            Bind<PaginationQueryParameterConverter>().ToSelf();
        }

        private void BindQueries()
        {
            Bind<IQuery<GetTaskDefinition>>().To<GetTaskDefinitionQuery>();

            Bind<IQuery<PaginatedTaskDefinitions>>().To<ListPaginatedTaskDefinitionsQuery>();
        }

        public void BindQueryRunners()
        {
            Bind<IQueryRunner<GetTaskDefinition, TaskDefinition>>().To<GetTaskDefinitionByIdQueryRunner>();

            Bind<IListPaginatedEntitiesRunner<PaginatedTaskDefinitions, TaskDefinition>>()
                .To<ListPaginatedTaskDefinitionsRunner>();
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
            Bind<IRequestProcessor<CreateTaskDefinitionRequest, TaskDefinitionContract>>()
                .To<CreateTaskDefinitionProcessor>();

            Bind<IRequestProcessor<GetTaskDefinitionByIdRequest, TaskDefinitionContract>>()
                .To<GetTaskDefinitionByIdRequestProcessor>();

            Bind<IRequestProcessor<ListPaginatedWithOrgIdRequest, PaginatedResult<IEnumerable<TaskDefinitionContract>>>>()
                .To<ListPaginatedTaskDefinitionsProcessor>();

            Bind<IRequestProcessor<UpdateTaskDefinitionRequest, TaskDefinitionContract>>()
                .To<UpdateTaskDefinitionProcessor>();
        }
    }
}
