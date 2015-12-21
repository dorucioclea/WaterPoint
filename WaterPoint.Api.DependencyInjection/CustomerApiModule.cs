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
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Dtos.Requests.Customers;
using WaterPoint.Core.RequestProcessor;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.Jobs;

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
            Bind<IQuery<PaginatedOrgIdIsProspect>>()
                .To<ListPaginatedCustomersQuery>()
                .WhenInjectedExactlyInto<ListPaginatedCustomersProcessor>();

            Bind<IQuery<GetCustomer>>().To<GetCustomerByIdQuery>();

            Bind<IQuery<PaginatedCustomerIdOrgId>>().To<ListPaginatedCustomerJobsQuery>();
        }

        public void BindQueryRunners()
        {
            Bind<IListPaginatedEntitiesRunner<PaginatedOrgIdIsProspect, Customer>>()
                .To<ListPaginatedCustomersRunner>();

            Bind<IQueryRunner<GetCustomer, Customer>>()
                .To<GetCustomerByIdQueryRunner>();

            Bind<IListPaginatedEntitiesRunner<PaginatedCustomerIdOrgId, JobWithCustomerAndStatusPoco>>()
                .To<ListPaginatedCustomerJobsRunner>();
        }

        public void BindCommands()
        {
            Bind<ICommand<CreateCustomer>>().To<CreateCustomerCommand>();
            Bind<ICommand<UpdateCustomer>>().To<UpdateCustomerByIdCommand>();
        }

        public void BindCommandExecutors()
        {
            Bind<ICommandExecutor<CreateCustomer>>()
                .To<CreateCommandExecutor<CreateCustomer>>();

            Bind<ICommandExecutor<UpdateCustomer>>()
                .To<UpdateCommandExecutor<UpdateCustomer>>();
        }

        private void BindRequestProcessors()
        {
            Bind<IRequestProcessor<ListCustomersRequest, PaginatedResult<IEnumerable<CustomerContract>>>>()
                .To<ListPaginatedCustomersProcessor>();

            Bind<IRequestProcessor<CreateCustomerRequest, CustomerContract>>()
                    .To<CreateCustomerProcessor>();

            Bind<IRequestProcessor<UpdateCustomerRequest, CustomerContract>>()
                .To<UpdateCustomerProcessor>();

            Bind<IRequestProcessor<GetCustomerByIdRequest, CustomerContract>>()
                .To<GetCustomerByIdProcessor>();

            Bind<IRequestProcessor<ListCustomerJobsRequest, PaginatedResult<IEnumerable<JobWithCustomerContract>>>>()
                .To<ListPaginatedCustomerJobsProcessor>();

        }
    }
}
