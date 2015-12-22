﻿using Ninject.Modules;
using WaterPoint.Core.Bll.Commands.CostItems;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.Bll.Queries.CostItems;
using WaterPoint.Core.Bll.QueryParameters.CostItems;
using WaterPoint.Core.Bll.QueryRunners.CostItems;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.CostItems;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Dtos.Requests.CostItems;
using WaterPoint.Core.RequestProcessor;
using WaterPoint.Core.RequestProcessor.CostItems;
using WaterPoint.Data.Entity.DataEntities;

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
            Bind<IQuery<GetCostItem>>().To<GetCostItemQuery>();
        }

        public void BindQueryRunners()
        {
            Bind<IQueryRunner<GetCostItem, CostItem>>().To<GetCostItemRunner>();
        }

        public void BindCommands()
        {
            Bind<ICommand<CreateCostItem>>().To<CreateCostItemCommand>();
        }

        public void BindCommandExecutors()
        {
            Bind<ICommandExecutor<CreateCostItem>>().To<CreateCommandExecutor<CreateCostItem>>();
        }

        private void BindRequestProcessors()
        {
            Bind<IRequestProcessor<CreateCostItemRequest, CostItemContract>>()
                .To<CreateCostItemProcessor>();

            Bind<IRequestProcessor<GetCostItemRequest, CostItemContract>>()
                .To<GetCostItemProcessor>();
        }
    }
}
