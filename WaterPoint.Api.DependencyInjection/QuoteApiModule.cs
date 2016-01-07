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
using WaterPoint.Data.Entity.Pocos.QuoteTasks;


namespace WaterPoint.Api.DependencyInjection
{
    public class QuoteApiModule : NinjectModule
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
            Bind<IQuery<ListQuotes>>().To<ListQuotesQuery>();
            Bind<IQuery<GetQuote>>().To<GetQuoteQuery>();


            Bind<IQuery<ListQuoteCostItems>>().To<ListQuoteCostItemsQuery>();
            Bind<IQuery<ListQuoteTasks>>().To<ListQuoteTasksQuery>();
            Bind<IQuery<GetQuoteTask>>().To<GetQuoteTaskQuery>();
            Bind<IQuery<GetQuoteCostItem>>().To<GetQuoteCostItemQuery>();
        }

        public void BindQueryRunners()
        {
            Bind<IPagedQueryRunner<ListQuoteCostItems, QuoteCostItemBasicPoco>>()
                .To<PagedQueryRunner<ListQuoteCostItems, QuoteCostItemBasicPoco>>();

            Bind<IPagedQueryRunner<ListQuoteTasks, QuoteTaskBasicPoco>>()
                .To<PagedQueryRunner<ListQuoteTasks, QuoteTaskBasicPoco>>();

            Bind<IQueryRunner<GetQuoteTask, QuoteTask>>()
                .To<QueryRunner<GetQuoteTask, QuoteTask>>();

            Bind<IQueryRunner<GetQuoteCostItem, QuoteCostItem>>()
                .To<QueryRunner<GetQuoteCostItem, QuoteCostItem>>();
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

        public void BindCommandExecutors()
        {
            Bind<ICommandExecutor<CreateQuote>>().To<CreateCommandExecutor<CreateQuote>>();
            Bind<ICommandExecutor<UpdateQuote>>().To<UpdateCommandExecutor<UpdateQuote>>();

            Bind<ICommandExecutor<CreateQuoteTask>>().To<CreateCommandExecutor<CreateQuoteTask>>();
            Bind<ICommandExecutor<UpdateQuoteTask>>().To<UpdateCommandExecutor<UpdateQuoteTask>>();

            Bind<ICommandExecutor<CreateQuoteCostItem>>().To<CreateCommandExecutor<CreateQuoteCostItem>>();
            Bind<ICommandExecutor<UpdateQuoteCostItem>>().To<UpdateCommandExecutor<UpdateQuoteCostItem>>();
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
