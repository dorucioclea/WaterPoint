using Ninject.Modules;
using WaterPoint.Core.Bll.Commands.QuoteCostItems;
using WaterPoint.Core.Bll.Commands.Quotes;
using WaterPoint.Core.Bll.Commands.QuoteTasks;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.Bll.Queries.QuoteCostItems;
using WaterPoint.Core.Bll.Queries.Quotes;
using WaterPoint.Core.Bll.Queries.QuoteTasks;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.QuoteCostItems;
using WaterPoint.Core.Domain.Contracts.QuoteTasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.QuoteCostItems;
using WaterPoint.Core.Domain.QueryParameters.Quotes;
using WaterPoint.Core.Domain.QueryParameters.QuoteTasks;
using WaterPoint.Core.Domain.Requests.QuoteCostItems;
using WaterPoint.Core.Domain.Requests.Quotes;
using WaterPoint.Core.Domain.Requests.QuoteTasks;
using WaterPoint.Core.RequestProcessor.QuoteCostItems;
using WaterPoint.Core.RequestProcessor.Quotes;
using WaterPoint.Core.RequestProcessor.QuoteTasks;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.QuoteCostItems;
using WaterPoint.Data.Entity.Pocos.Quotes;
using WaterPoint.Data.Entity.Pocos.QuoteTasks;


namespace WaterPoint.Api.DependencyInjection
{
    public class QuoteApiModule : NinjectModule
    {
        public override void Load()
        {
            BindRequestProcessors();
            BindQueries();
            BindCommands();
        }

        private void BindQueries()
        {
            Bind<IQuery<ListQuotes, QuoteBasicPoco>>().To<ListQuotesQuery>();
            Bind<IQuery<GetQuote, Quote>>().To<GetQuoteQuery>();


            Bind<IQuery<ListQuoteCostItems, QuoteCostItemBasicPoco>>().To<ListQuoteCostItemsQuery>();
            Bind<IQuery<ListQuoteTasks, QuoteTaskBasicPoco>>().To<ListQuoteTasksQuery>();
            Bind<IQuery<GetQuoteTask, QuoteTask>>().To<GetQuoteTaskQuery>();
            Bind<IQuery<GetQuoteCostItem, QuoteCostItem>>().To<GetQuoteCostItemQuery>();
        }

        public void BindCommands()
        {
            Bind<ICommand<CreateQuote>>().To<CreateQuoteCommand>();
            Bind<ICommand<UpdateQuote>>().To<UpdateQuoteCommand>();

            Bind<ICommand<CreateQuoteTask>>().To<CreateQuoteTaskCommand>();
            Bind<ICommand<UpdateQuoteTask>>().To<UpdateQuoteTaskCommand>();

            Bind<ICommand<CreateQuoteCostItem>>().To<CreateQuoteCostItemCommand>();
            Bind<ICommand<UpdateQuoteCostItem>>().To<UpdateQuoteCostItemCommand>();
        }

        private void BindRequestProcessors()
        {
            Bind<IWriteRequestProcessor<CreateQuoteRequest>>()
                .To<CreateQuoteProcessor>();
            Bind<IWriteRequestProcessor<CreateQuoteRequest>>()
                .To<CreateQuoteProcessor>();

            Bind<IWriteRequestProcessor<CreateQuoteTaskRequest>>()
                .To<CreateQuoteTaskProcessor>();
            Bind<IWriteRequestProcessor<CreateQuoteCostItemRequest>>()
                .To<CreateQuoteCostItemProcessor>();

            Bind<ISimplePagedProcessor<ListQuoteTasksRequest, QuoteTaskBasicContract>>()
                .To<ListQuoteTasksProcessor>();
            Bind<ISimplePagedProcessor<ListQuoteCostItemsRequest, QuoteCostItemBasicContract>>()
                .To<ListQuoteCostItemsProcessor>();

            Bind<IRequestProcessor<GetQuoteTaskRequest, QuoteTaskContract>>()
                .To<GetQuoteTaskProcessor>();
            Bind<IRequestProcessor<GetQuoteCostItemRequest, QuoteCostItemContract>>()
                .To<GetQuoteCostItemProcessor>();
        }
    }
}
