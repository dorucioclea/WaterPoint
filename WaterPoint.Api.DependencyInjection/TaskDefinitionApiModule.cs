﻿using Ninject.Modules;
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
using WaterPoint.Core.Domain.QueryParameters;
using WaterPoint.Core.Domain.Requests;
using WaterPoint.Core.Domain.Requests.Shared;
using WaterPoint.Core.Domain.Requests.TaskDefinitions;
using WaterPoint.Core.RequestProcessor;
using WaterPoint.Core.RequestProcessor.TaskDefinitions;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.TaskDefinitions;

namespace WaterPoint.Api.DependencyInjection
{
    public class TaskDefinitionApiModule : NinjectModule
    {
        public override void Load()
        {
            BindRequestProcessors();
            BindQueries();
            BindCommands();
        }

        private void BindQueries()
        {
            Bind<IQuery<GetTaskDefinition, TaskDefinition>>().To<GetTaskDefinitionQuery>();

            Bind<IQuery<PagedOrgId, TaskDefinitionBasicPoco>>().To<ListTaskDefinitionsQuery>();

            Bind<IQuery<SearchByName, TaskDefinitionBasicPoco>>().To<SearchTaskDefByNameQuery>();
        }

        public void BindCommands()
        {
            Bind<ICommand<CreateTaskDefinition>>().To<CreateTaskDefinitionCommand>();
            Bind<ICommand<UpdateTaskDefinition>>().To<UpdateTaskDefinitionCommand>();
        }

        private void BindRequestProcessors()
        {
            Bind<IWriteRequestProcessor<CreateTaskDefinitionRequest>>()
                .To<CreateTaskDefinitionProcessor>();

            Bind<IRequestProcessor<GetTaskDefinitionByIdRequest, TaskDefinitionContract>>()
                .To<GetTaskDefinitionByIdRequestProcessor>();

            Bind<IPagedProcessor<ListWithOrgIdRequest, TaskDefinitionBasicContract>>()
                .To<ListTaskDefinitionsProcessor>();

            Bind<IWriteRequestProcessor<UpdateTaskDefinitionRequest>>()
                .To<UpdateTaskDefinitionProcessor>();

            Bind<IListProcessor<SearchTermRequest, TaskDefinitionBasicContract>>()
                .To<SearchTaskDefByNameProcessor>();
        }
    }
}
