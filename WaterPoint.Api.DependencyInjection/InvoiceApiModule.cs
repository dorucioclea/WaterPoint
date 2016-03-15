using Ninject.Modules;
using WaterPoint.Core.Bll.Commands.InvoiceCostItems;
using WaterPoint.Core.Bll.Commands.Invoices;
using WaterPoint.Core.Bll.Commands.InvoiceJobTasks;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.Bll.Queries.InvoiceCostItems;
using WaterPoint.Core.Bll.Queries.InvoiceJobTasks;
using WaterPoint.Core.Bll.Queries.Invoices;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.InvoiceCostItems;
using WaterPoint.Core.Domain.Contracts.InvoiceJobTasks;
using WaterPoint.Core.Domain.Contracts.Invoices;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters;
using WaterPoint.Core.Domain.QueryParameters.InvoiceCostItems;
using WaterPoint.Core.Domain.QueryParameters.Invoices;
using WaterPoint.Core.Domain.QueryParameters.InvoiceJobTasks;
using WaterPoint.Core.Domain.Requests;
using WaterPoint.Core.Domain.Requests.InvoiceCostItems;
using WaterPoint.Core.Domain.Requests.Invoices;
using WaterPoint.Core.Domain.Requests.InvoiceJobTasks;
using WaterPoint.Core.RequestProcessor.InvoiceCostItems;
using WaterPoint.Core.RequestProcessor.InvoiceJobTasks;
using WaterPoint.Core.RequestProcessor.Invoices;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.InvoiceCostItems;
using WaterPoint.Data.Entity.Pocos.InvoiceJobTasks;


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
            Bind<IQuery<ListInvoiceJobTasks, InvoiceJobTaskBasicPoco>>().To<ListInvoiceJobTasksQuery>();
            Bind<IQuery<GetInvoiceJobTask, InvoiceJobTask>>().To<GetInvoiceJobTaskQuery>();
            Bind<IQuery<GetInvoiceCostItem, InvoiceCostItem>>().To<GetInvoiceCostItemQuery>();
            Bind<IQuery<GetOrganizationEntity, Invoice>>().To<GetInvoiceQuery>();
        }

        public void BindCommands()
        {
            Bind<ICommand<CreateInvoice>>().To<CreateInvoiceCommand>();
            Bind<ICommand<CreateInvoiceJobTask>>().To<CreateInvoiceJobTaskCommand>();
            Bind<ICommand<UpdateInvoiceJobTask>>().To<UpdateInvoiceJobTaskCommand>();
            Bind<ICommand<CreateInvoiceCostItem>>().To<CreateInvoiceCostItemCommand>();
            Bind<ICommand<UpdateInvoiceCostItem>>().To<UpdateInvoiceCostItemCommand>();
            Bind<ICommand<UpdateInvoice>>().To<UpdateInvoiceCommand>();
        }

        private void BindRequestProcessors()
        {
            Bind<IWriteRequestProcessor<CreateInvoiceRequest>>()
                .To<CreateInvoiceProcessor>();

            Bind<IWriteRequestProcessor<CreateInvoiceJobTaskRequest>>()
                .To<CreateInvoiceJobTaskProcessor>();

            Bind<ISimplePagedProcessor<ListInvoiceJobTasksRequest, InvoiceJobTaskBasicContract>>()
                .To<ListInvoiceJobTasksProcessor>();

            Bind<IRequestProcessor<GetInvoiceJobTaskRequest, InvoiceJobTaskContract>>()
                .To<GetInvoiceJobTaskProcessor>();

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
