using Ninject.Modules;
using WaterPoint.Core.Bll.Commands.Addresses;
using WaterPoint.Core.Bll.Commands.Contacts;
using WaterPoint.Core.Bll.Commands.Customers;
using WaterPoint.Core.Bll.Queries.Addresses;
using WaterPoint.Core.Bll.Queries.Contacts;
using WaterPoint.Core.Bll.Queries.Customers;
using WaterPoint.Core.Domain.QueryParameters.Customers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Addresses;
using WaterPoint.Core.Domain.Contracts.Contacts;
using WaterPoint.Core.RequestProcessor.Customers;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Addresses;
using WaterPoint.Core.Domain.QueryParameters.Contacts;
using WaterPoint.Core.Domain.Requests.Addresses;
using WaterPoint.Core.Domain.Requests.Contacts;
using WaterPoint.Core.Domain.Requests.Customers;
using WaterPoint.Core.RequestProcessor.Addresses;
using WaterPoint.Core.RequestProcessor.Contacts;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.Addresses;
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

            Bind<IQuery<ListAddressesForCustomer, CustomerAddressPoco>>().To<ListAddressesForCustomerQuery>();

            Bind<IQuery<GetAddressForCustomer, CustomerAddressPoco>>().To<GetAddressForCustomerQuery>();

            Bind<IQuery<GetAddress, Address>>().To<GetAddressQuery>();
        }

        public void BindCommands()
        {
            Bind<ICommand<CreateCustomer>>().To<CreateCustomerCommand>();
            Bind<ICommand<UpdateCustomer>>().To<UpdateCustomerCommand>();
            Bind<ICommand<CreateContact>>().To<CreateContactCommand>();
            Bind<ICommand<CreateCustomerContact>>().To<CreateCustomerContactCommand>();
            Bind<ICommand<UpdateContact>>().To<UpdateContactCommand>();
            Bind<ICommand<CreateAddress>>().To<CreateAddressCommand>();
            Bind<ICommand<CreateCustomerAddress>>().To<CreateCustomerAddressCommand>();
            Bind<ICommand<UpdateAddress>>().To<UpdateAddressCommand>();
            Bind<ICommand<UpdateCustomerAddressIsPrimary>>().To<UpdateCustomerAddressIsPrimaryCommand>();
            Bind<ICommand<UpdateCustomerAddressIsPostAddress>>().To<UpdateCustomerAddressIsPostAddressCommand>();
            Bind<ICommand<DeleteCustomer>>().To<DeleteCustomerCommand>();
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

            Bind<IWriteRequestProcessor<UpdateContactRequest>>()
                .To<UpdateContactProcessor>();

            Bind<IWriteRequestProcessor<CreateAddressForCustomerRequest>>()
                .To<CreateAddressForCustomerProcessor>();

            Bind<IListProcessor<ListAddressesForCustomerRequest, CustomerAddressContract>>()
                .To<ListAddressesForCustomerProcessor>();

            Bind<IRequestProcessor<GetAddressForCustomerRequest, CustomerAddressContract>>()
                .To<GetAddressForCustomerProcessor>();

            Bind<IWriteRequestProcessor<UpdateAddressForCustomerRequest>>()
                .To<UpdateAddressForCustomerProcessor>();

            Bind<IWriteRequestProcessor<DeleteCustomersRequest>>()
                .To<DeleteCustomerProcessor>();

        }
    }
}
