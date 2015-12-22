using System.Collections.Generic;
using Ninject.Modules;
using WaterPoint.Core.Bll.Commands.CostItems;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.Bll.Queries.CostItems;
using WaterPoint.Core.Bll.QueryParameters.CostItems;
using WaterPoint.Core.Bll.QueryParameters.Shared;
using WaterPoint.Core.Bll.QueryRunners;
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

            Bind<IQuery<PaginatedOrgId>>().To<ListCostItemsQuery>();
        }

        public void BindQueryRunners()
        {
            Bind<IQueryRunner<GetCostItem, CostItem>>().To<GetCostItemRunner>();

            Bind<IListEntitiesRunner<PaginatedOrgId, CostItem>>().To<ListCostItemsRunner>();
        }

        public void BindCommands()
        {
            Bind<ICommand<CreateCostItem>>().To<CreateCostItemCommand>();
            Bind<ICommand<UpdateCostItem>>().To<UpdateCostItemCommand>();
        }

        public void BindCommandExecutors()
        {
            Bind<ICommandExecutor<CreateCostItem>>().To<CreateCommandExecutor<CreateCostItem>>();
            Bind<ICommandExecutor<UpdateCostItem>>().To<UpdateCommandExecutor<UpdateCostItem>>();
        }

        private void BindRequestProcessors()
        {
            Bind<IRequestProcessor<CreateCostItemRequest, CostItemContract>>()
                .To<CreateCostItemProcessor>();

            Bind<IRequestProcessor<GetCostItemRequest, CostItemContract>>()
                .To<GetCostItemProcessor>();

            Bind<IRequestProcessor<ListCostItemsRequest, PaginatedResult<CostItemContract>>>()
                .To<ListCostItemsProcessor>();

            Bind<IRequestProcessor<UpdateCostItemRequest, CostItemContract>>()
                .To<UpdateCostItemProcessor>();
        }
    }
}
