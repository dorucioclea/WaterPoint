using Ninject.Modules;
using WaterPoint.Core.Bll.Commands.Suppliers;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.Bll.Queries.Suppliers;
using WaterPoint.Core.Bll.Queries.Suppliers;
using WaterPoint.Core.Domain.QueryParameters.Suppliers;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.RequestProcessor.Suppliers;
using WaterPoint.Core.Domain.Contracts.Suppliers;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Suppliers;
using WaterPoint.Core.Domain.Requests.Suppliers;
using WaterPoint.Core.RequestProcessor.Suppliers;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.Jobs;

namespace WaterPoint.Api.DependencyInjection
{
    public class SupplierApiModule : NinjectModule
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
            Bind<IQuery<ListSuppliers>>()
                .To<ListSuppliersQuery>()
                .WhenInjectedExactlyInto<ListSuppliersProcessor>();
        }

        public void BindQueryRunners()
        {
            Bind<IPagedQueryRunner<ListSuppliers, Supplier>>()
                .To<PagedQueryRunner< ListSuppliers, Supplier>>();
        }

        public void BindCommands()
        {
            Bind<ICommand<CreateSupplier>>().To<CreateSupplierCommand>();
        }

        public void BindCommandExecutors()
        {
            Bind<ICommandExecutor<CreateSupplier>>()
                .To<CreateCommandExecutor<CreateSupplier>>();
        }

        private void BindRequestProcessors()
        {
            Bind<IPagedProcessor<ListSuppliersRequest, SupplierContract>>()
                .To<ListSuppliersProcessor>();

            Bind<IWriteRequestProcessor<CreateSupplierRequest>>()
                    .To<CreateSupplierProcessor>();

        }
    }
}
