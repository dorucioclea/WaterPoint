using Ninject.Modules;
using WaterPoint.Core.Bll.Commands.Customers;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.Bll.Queries.Customers;
using WaterPoint.Core.Domain.QueryParameters.Customers;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.RequestProcessor.Customers;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Requests.Customers;
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
        }

        private void BindQueries()
        {
            Bind<IQuery<ListCustomers>>()
                .To<ListCustomersQuery>()
                .WhenInjectedExactlyInto<ListCustomersProcessor>();

            Bind<IQuery<GetCustomer>>().To<GetCustomerQuery>();

            Bind<IQuery<ListCustomerJobs>>().To<ListCustomerJobsQuery>();
        }

        public void BindQueryRunners()
        {
            Bind<IPagedQueryRunner<ListCustomers, Customer>>()
                .To<PagedQueryRunner<ListCustomers, Customer>>();

            Bind<IQueryRunner<GetCustomer, Customer>>()
                .To<QueryRunner<GetCustomer, Customer>>();

            Bind<IPagedQueryRunner<ListCustomerJobs, JobWithStatusPoco>>()
                .To<PagedQueryRunner<ListCustomerJobs, JobWithStatusPoco>>();
        }

        public void BindCommands()
        {
            Bind<ICommand<CreateCustomer>>().To<CreateCustomerCommand>();
            Bind<ICommand<UpdateCustomer>>().To<UpdateCustomerCommand>();
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
            Bind<IPagedProcessor<ListCustomersRequest, CustomerContract>>()
                .To<ListCustomersProcessor>();

            Bind<IWriteRequestProcessor<CreateCustomerRequest>>()
                    .To<CreateCustomerProcessor>();

            Bind<IWriteRequestProcessor<UpdateCustomerRequest>>()
                .To<UpdateCustomerProcessor>();

            Bind<IRequestProcessor<GetCustomerRequest, CustomerContract>>()
                .To<GetCustomerProcessor>();

            Bind<ISimplePagedProcessor<ListCustomerJobsRequest, JobWithStatusContract>>()
                .To<ListCustomerJobsProcessor>();

        }
    }
}
