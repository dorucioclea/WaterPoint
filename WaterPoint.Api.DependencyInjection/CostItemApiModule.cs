using System.Collections.Generic;
using Ninject.Modules;
using WaterPoint.Core.Bll.Commands.CostItems;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.Bll.Queries.CostItems;
using WaterPoint.Core.Domain.QueryParameters.CostItems;
using WaterPoint.Core.Domain.QueryParameters.Shared;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Contracts.CostItems;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters;
using WaterPoint.Core.Domain.Requests;
using WaterPoint.Core.Domain.Requests.CostItems;
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
            BindCommands();
        }

        private void BindQueries()
        {
            Bind<IQuery<GetCostItem, CostItem>>().To<GetCostItemQuery>();

            Bind<IQuery<PagedOrgId, CostItem>>().To<ListCostItemsQuery>();
        }

        public void BindCommands()
        {
            Bind<ICommand<CreateCostItem>>().To<CreateCostItemCommand>();
            Bind<ICommand<UpdateCostItem>>().To<UpdateCostItemCommand>();
            Bind<ICommand<ToggleIsDelete>>().To<DeleteCostItemCommand>()
                .WhenInjectedExactlyInto<DeleteCostItemProcessor>();
        }

        private void BindRequestProcessors()
        {
            Bind<IWriteRequestProcessor<CreateCostItemRequest>>()
                .To<CreateCostItemProcessor>();

            Bind<IRequestProcessor<GetCostItemRequest, CostItemContract>>()
                .To<GetCostItemProcessor>();

            Bind<IPagedProcessor<ListCostItemsRequest, CostItemContract>>()
                .To<ListCostItemsProcessor>();

            Bind<IWriteRequestProcessor<UpdateCostItemRequest>>()
                .To<UpdateCostItemProcessor>();

            Bind<IDeleteRequestProcessor<OrganizationEntityRequest>>()
                .To<DeleteCostItemProcessor>();
        }
    }
}
