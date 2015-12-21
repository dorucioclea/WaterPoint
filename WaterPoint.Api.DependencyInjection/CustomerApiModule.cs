using System.Collections.Generic;
using Ninject.Modules;
using WaterPoint.Core.Bll.Commands.Customers;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.Bll.Queries.Customers;
using WaterPoint.Core.Bll.QueryParameters;
using WaterPoint.Core.Bll.QueryParameters.Customers;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Bll.QueryRunners.Customers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.RequestProcessor.Customers;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Contracts.Jobs;
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
            BindQueries();
            BindQueryRunners();
            BindCommands();
            BindCommandExecutors();
            Bind<PaginationQueryParameterConverter>().ToSelf();
        }

        private void BindQueries()
        {
            Bind<IListPaginatedWithOrgIdQuery<PaginatedWithOrgIdQueryParameter>>()
                .To<ListPaginatedCustomersQuery>()
                .WhenInjectedExactlyInto<ListPaginatedCustomersProcessor>();

            Bind<IQuery<GetCustomerQueryParameter>>().To<GetCustomerByIdQuery>();
        }

        public void BindQueryRunners()
        {
            Bind<IListPaginatedEntitiesRunner<PaginatedWithOrgIdQueryParameter, Customer>>()
                .To<ListPaginatedCustomersRunner>();

            Bind<IQueryRunner<GetCustomerQueryParameter, Customer>>()
                .To<GetCustomerByIdQueryRunner>();
        }

        public void BindCommands()
        {
            Bind<ICommand<CreateCustomerQueryParameter>>().To<CreateCustomerCommand>();
            Bind<ICommand<UpdateCustomerQueryParameter>>().To<UpdateCustomerByIdCommand>();
        }

        public void BindCommandExecutors()
        {
            Bind<ICommandExecutor<CreateCustomerQueryParameter>>()
                .To<CreateCommandExecutor<CreateCustomerQueryParameter>>();

            Bind<ICommandExecutor<UpdateCustomerQueryParameter>>()
                .To<UpdateCommandExecutor<UpdateCustomerQueryParameter>>();
        }

        private void BindRequestProcessors()
        {
            Bind<IRequestProcessor<ListPaginatedWithOrgIdRequest, PaginatedResult<IEnumerable<CustomerContract>>>>()
                .To<ListPaginatedCustomersProcessor>();

            Bind<IRequestProcessor<CreateCustomerRequest, CustomerContract>>()
                    .To<CreateCustomerProcessor>();

            Bind<IRequestProcessor<UpdateCustomerRequest, CustomerContract>>()
                .To<UpdateCustomerProcessor>();

            Bind<IRequestProcessor<GetCustomerByIdRequest, CustomerContract>>()
                .To<GetCustomerByIdProcessor>();

            Bind<IRequestProcessor<ListPaginatedCustomerJobsRequest, JobWithCustomerContract>>()
                .To<ListPaginatedCustomerJobsProcessor>();

        }
    }
}
