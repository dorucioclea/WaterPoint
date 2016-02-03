using Ninject.Modules;
using WaterPoint.Core.Bll.Commands.Invoices;
using WaterPoint.Core.Bll.Commands.InvoiceJobTasks;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.Bll.Queries.InvoiceJobCostItems;
using WaterPoint.Core.Bll.Queries.InvoiceJobTasks;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.InvoiceJobTasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.InvoiceJobCostItems;
using WaterPoint.Core.Domain.QueryParameters.Invoices;
using WaterPoint.Core.Domain.QueryParameters.InvoiceJobTasks;
using WaterPoint.Core.Domain.Requests.Invoices;
using WaterPoint.Core.Domain.Requests.InvoiceJobTasks;
using WaterPoint.Core.RequestProcessor.InvoiceJobTasks;
using WaterPoint.Core.RequestProcessor.Invoices;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.InvoiceJobCostItems;
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
            Bind<IQuery<ListInvoiceJobCostItems, InvoiceJobCostItemBasicPoco>>().To<ListInvoiceJobCostItemsQuery>();
            Bind<IQuery<ListInvoiceJobTasks, InvoiceJobTaskBasicPoco>>().To<ListInvoiceJobTasksQuery>();
            Bind<IQuery<GetInvoiceJobTask, InvoiceJobTask>>().To<GetInvoiceJobTaskQuery>();
            Bind<IQuery<GetInvoiceJobCostItem, InvoiceJobCostItem>>().To<GetInvoiceJobCostItemQuery>();
        }

        public void BindCommands()
        {
            Bind<ICommand<CreateInvoice>>().To<CreateInvoiceCommand>();
            Bind<ICommand<CreateInvoiceJobTask>>().To<CreateInvoiceJobTaskCommand>();
            Bind<ICommand<UpdateInvoiceJobTask>>().To<UpdateInvoiceJobTaskCommand>();
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
        }
    }
}
