using Ninject.Modules;
using WaterPoint.Core.Bll.Commands.Addresses;
using WaterPoint.Core.Bll.Commands.Contacts;
using WaterPoint.Core.Bll.Commands.Customers;
using WaterPoint.Core.Bll.Commands.Customers.WaterPoint.Core.Bll.Commands.Customers;
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
using WaterPoint.Core.Domain.QueryParameters;
using WaterPoint.Core.Domain.QueryParameters.Addresses;
using WaterPoint.Core.Domain.QueryParameters.Contacts;
using WaterPoint.Core.Domain.Requests;
using WaterPoint.Core.Domain.Requests.Addresses;
using WaterPoint.Core.Domain.Requests.Contacts;
using WaterPoint.Core.Domain.Requests.Customers;
using WaterPoint.Core.RequestProcessor.Addresses;
using WaterPoint.Core.RequestProcessor.Contacts;
using WaterPoint.Core.RequestProcessor.CostItems;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.Addresses;
using WaterPoint.Data.Entity.Pocos.Contacts;
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

            Bind<IQuery<ListCustomerContacts, CustomerContactPoco>>().To<ListCustomerContactsQuery>();

            Bind<IQuery<ListCustomerAddresses, CustomerAddressPoco>>().To<ListCustomerAddressesQuery>();

            Bind<IQuery<GetCustomerAddress, CustomerAddressPoco>>().To<GetCustomerAddressQuery>();

            Bind<IQuery<GetAddress, Address>>().To<GetAddressQuery>();
        }

        public void BindCommands()
        {
            Bind<ICommand<CreateCustomer>>().To<CreateCustomerCommand>();
            Bind<ICommand<UpdateCustomer>>().To<UpdateCustomerCommand>();
            Bind<ICommand<CreateCustomerContact>>().To<CreateCustomerContactCommand>();
            Bind<ICommand<CreateCustomerAddress>>().To<CreateCustomerAddressCommand>();
            Bind<ICommand<UpdateCustomerAddressIsPrimary>>().To<UpdateCustomerAddressIsPrimaryCommand>();
            Bind<ICommand<UpdateCustomerAddressIsPostAddress>>().To<UpdateCustomerAddressIsPostAddressCommand>();
            Bind<ICommand<ToggleIsDelete>>().To<ToggleIsDeleteCustomerCommand>();
            Bind<ICommand<BulkDeleteCustomer>>().To<BulkDeleteCustomerCommand>();
            Bind<ICommand<UpdateCustomerContactIsPrimary>>().To<UpdateCustomerContactIsPrimaryCommand>();
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

            Bind<IListProcessor<ListCustomerContactsRequest, CustomerContactContract>>()
                .To<ListCustomerContactProcessor>();

            Bind<IWriteRequestProcessor<CreateCustomerContactRequest>>()
                .To<CreateCustomerContactProcessor>();

            Bind<IWriteRequestProcessor<UpdateCustomerContactRequest>>()
                .To<UpdateCustomerContactProcessor>();

            Bind<IWriteRequestProcessor<CreateCustomerAddressRequest>>()
                .To<CreateCustomerAddressProcessor>();

            Bind<IListProcessor<ListCustomerAddressesRequest, CustomerAddressContract>>()
                .To<ListCustomerAddressesProcessor>();

            Bind<IRequestProcessor<GetCustomerAddressRequest, CustomerAddressContract>>()
                .To<GetCustomerAddressProcessor>();

            Bind<IWriteRequestProcessor<UpdateCustomerAddressRequest>>()
                .To<UpdateCustomerAddressProcessor>();

            Bind<IDeleteRequestProcessor<OrganizationEntityRequest>>()
                .To<DeleteCustomerProcessor>();

            Bind<IDeleteRequestProcessor<BulkDeleteCustomersRequest>>()
                .To<BulkDeleteCustomersRequestProcessor>();
        }
    }
}
