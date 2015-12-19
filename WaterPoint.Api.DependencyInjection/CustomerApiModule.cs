using System.Collections.Generic;
using Ninject.Modules;
using WaterPoint.Core.Bll.Commands.Customers;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.Bll.Queries.Customers;
using WaterPoint.Core.Bll.QueryParameters;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Bll.QueryRunners.Customers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.RequestProcessor.Customers;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Dtos.Requests.Customers;
using WaterPoint.Core.Domain.Dtos.Requests.Shared;
using WaterPoint.Core.RequestProcessor;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Api.DependencyInjection
{
    public class CustomerApiModule : NinjectModule
    {
        public override void Load()
        {
            BindRequestProcessors();
            BindQueriesAndCommands();
        }

        private void BindQueriesAndCommands()
        {
            Bind<IListPaginatedWithOrgIdQuery<PaginatedWithOrgIdQueryParameter>>()
                .To<ListPaginatedCustomersQuery>()
                .WhenInjectedExactlyInto<ListPaginatedCustomersProcessor>();

            Bind<IListPaginatedEntitiesRunner<Customer>>()
                .To<ListPaginatedCustomersRunner>()
                .WhenInjectedExactlyInto<ListPaginatedCustomersProcessor>();

            Bind<PaginationQueryParameterConverter>().ToSelf();
            Bind<CreateCustomerCommand>().ToSelf();
            Bind<CreateCommandExecutor>().ToSelf();
            Bind<GetCustomerByIdQueryRunner>().ToSelf();
        }

        private void BindRequestProcessors()
        {
            Bind<IRequestProcessor<ListPaginatedWithOrgIdRequest, PaginatedResult<IEnumerable<CustomerContract>>>>()
                .To<ListPaginatedCustomersProcessor>();

            Bind<IRequestProcessor< CreateCustomerRequest, CustomerContract >>()
                    .To<CreateCustomerRequestProcessor>();
            Bind<IRequestProcessor<UpdateCustomerRequest, CustomerContract>>()
                .To<UpdateCustomerRequestProcessor>();
            Bind<IRequestProcessor<GetCustomerByIdRequest, CustomerContract>>()
                .To<GetCustomerByIdRequestProcessor>();

        }
    }
}
