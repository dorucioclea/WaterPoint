using Ninject.Modules;
using WaterPoint.Core.Bll.Commands.InvoiceCostItems;
using WaterPoint.Core.Bll.Commands.Invoices;
using WaterPoint.Core.Bll.Commands.InvoiceTasks;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.Bll.Queries.InvoiceCostItems;
using WaterPoint.Core.Bll.Queries.InvoiceTasks;
using WaterPoint.Core.Bll.Queries.Invoices;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.InvoiceCostItems;
using WaterPoint.Core.Domain.Contracts.InvoiceTasks;
using WaterPoint.Core.Domain.Contracts.Invoices;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters;
using WaterPoint.Core.Domain.QueryParameters.InvoiceCostItems;
using WaterPoint.Core.Domain.QueryParameters.Invoices;
using WaterPoint.Core.Domain.QueryParameters.InvoiceTasks;
using WaterPoint.Core.Domain.Requests;
using WaterPoint.Core.Domain.Requests.InvoiceCostItems;
using WaterPoint.Core.Domain.Requests.Invoices;
using WaterPoint.Core.Domain.Requests.InvoiceTasks;
using WaterPoint.Core.RequestProcessor.InvoiceCostItems;
using WaterPoint.Core.RequestProcessor.InvoiceTasks;
using WaterPoint.Core.RequestProcessor.Invoices;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.InvoiceCostItems;
using WaterPoint.Data.Entity.Pocos.InvoiceTasks;


namespace WaterPoint.Api.DependencyInjection
{
    public class InvoiceApiModule : NinjectModule
    {
        public override void Load()
        {
            BindRequestProcessors();
            BindQueries();
            BindCommands();
        }

        private void BindQueries()
        {
            Bind<IQuery<ListInvoiceCostItems, InvoiceCostItemBasicPoco>>().To<ListInvoiceCostItemsQuery>();
            Bind<IQuery<ListInvoiceTasks, InvoiceTaskBasicPoco>>().To<ListInvoiceTasksQuery>();
            Bind<IQuery<GetInvoiceTask, InvoiceTask>>().To<GetInvoiceTaskQuery>();
            Bind<IQuery<GetInvoiceCostItem, InvoiceCostItem>>().To<GetInvoiceCostItemQuery>();
            Bind<IQuery<GetOrganizationEntity, Invoice>>().To<GetInvoiceQuery>();
        }

        public void BindCommands()
        {
            Bind<ICommand<CreateInvoice>>().To<CreateInvoiceCommand>();
            Bind<ICommand<CreateInvoiceTask>>().To<CreateInvoiceTaskCommand>();
            Bind<ICommand<UpdateInvoiceTask>>().To<UpdateInvoiceTaskCommand>();
            Bind<ICommand<CreateInvoiceCostItem>>().To<CreateInvoiceCostItemCommand>();
            Bind<ICommand<UpdateInvoiceCostItem>>().To<UpdateInvoiceCostItemCommand>();
            Bind<ICommand<UpdateInvoice>>().To<UpdateInvoiceCommand>();
        }

        private void BindRequestProcessors()
        {
            Bind<IWriteRequestProcessor<CreateInvoiceRequest>>()
                .To<CreateInvoiceProcessor>();

            Bind<IWriteRequestProcessor<CreateInvoiceTaskRequest>>()
                .To<CreateInvoiceTaskProcessor>();

            Bind<ISimplePagedProcessor<ListInvoiceTasksRequest, InvoiceTaskBasicContract>>()
                .To<ListInvoiceTasksProcessor>();

            Bind<IRequestProcessor<GetInvoiceTaskRequest, InvoiceTaskContract>>()
                .To<GetInvoiceTaskProcessor>();

            Bind<IWriteRequestProcessor<CreateInvoiceCostItemRequest>>()
                .To<CreateInvoiceCostItemProcessor>();

            Bind<ISimplePagedProcessor<ListInvoiceCostItemsRequest, BasicInvoiceCostItemContract>>()
                .To<ListInvoiceCostItemsProcessor>();

            Bind<IWriteRequestProcessor<UpdateInvoiceCostItemRequest>>()
                .To<UpdateInvoiceCostItemProcessor>();

            Bind<IRequestProcessor<OrganizationEntityRequest, InvoiceContract>>()
                .To<GetInvoiceProcessor>();

            Bind<IWriteRequestProcessor<UpdateInvoiceRequest>>()
                .To<UpdateInvoiceProcessor>();
        }
    }
}
