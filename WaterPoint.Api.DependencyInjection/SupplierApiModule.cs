using Ninject.Modules;
using WaterPoint.Core.Bll.Commands.Suppliers;
using WaterPoint.Core.Bll.Queries.Suppliers;
using WaterPoint.Core.Domain.QueryParameters.Suppliers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.RequestProcessor.Suppliers;
using WaterPoint.Core.Domain.Contracts.Suppliers;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Requests.Suppliers;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Api.DependencyInjection
{
    public class SupplierApiModule : NinjectModule
    {
        public override void Load()
        {
            BindRequestProcessors();
            BindQueries();
            BindCommands();
        }

        private void BindQueries()
        {
            Bind<IQuery<ListSuppliers, Supplier>>()
                .To<ListSuppliersQuery>()
                .WhenInjectedExactlyInto<ListSuppliersProcessor>();
        }

        public void BindCommands()
        {
            Bind<ICommand<CreateSupplier>>().To<CreateSupplierCommand>();
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
