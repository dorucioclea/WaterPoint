using Ninject.Modules;
using WaterPoint.Core.Bll.Commands.Contacts;
using WaterPoint.Core.Bll.Commands.Customers;
using WaterPoint.Core.Bll.Queries.Contacts;
using WaterPoint.Core.Bll.Queries.Customers;
using WaterPoint.Core.Domain.QueryParameters.Customers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Contacts;
using WaterPoint.Core.RequestProcessor.Customers;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Contacts;
using WaterPoint.Core.Domain.Requests.Contacts;
using WaterPoint.Core.Domain.Requests.Customers;
using WaterPoint.Core.RequestProcessor.Contacts;
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
            BindCommands();
        }

        private void BindQueries()
        {
            Bind<IQuery<ListCustomers, Customer>>()
                .To<ListCustomersQuery>()
                .WhenInjectedExactlyInto<ListCustomersProcessor>();

            Bind<IQuery<GetCustomer, Customer>>().To<GetCustomerQuery>();

            Bind<IQuery<ListCustomerJobs, JobWithStatusPoco>>().To<ListCustomerJobsQuery>();

            Bind<IQuery<SearchTop10Customers, Customer>>().To<SearchTop10CustomersQuery>();

            Bind<IQuery<ListContactsForCustomer, Contact>>().To<ListContactsForCustomerQuery>();

            Bind<IQuery<GetContact, Contact>>().To<GetContactQuery>();
        }

        public void BindCommands()
        {
            Bind<ICommand<CreateCustomer>>().To<CreateCustomerCommand>();
            Bind<ICommand<UpdateCustomer>>().To<UpdateCustomerCommand>();
            Bind<ICommand<CreateContact>>().To<CreateContactContactCommand>();
            Bind<ICommand<CreateCustomerContact>>().To<CreateCustomerContactCommand>();
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

            Bind<IListProcessor<SearchTop10CustomerRequest, CustomerContract>>()
                .To<SearchTop10Processor>();


            Bind<IListProcessor<ListContactsForCustomerRequest, ContactContract>>()
                .To<ListContactsForCustomerProcessor>();

            Bind<IWriteRequestProcessor<CreateContactForCustomerRequest>>()
                .To<CreateContactForCustomerProcessor>();

            Bind<IRequestProcessor<GetContactRequest, ContactContract>>()
                .To<GetContactProcessor>();

        }
    }
}
