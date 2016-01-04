﻿using Ninject.Modules;
using WaterPoint.Api.Common;
using WaterPoint.Core.Bll.Commands.JobTimesheet;
using WaterPoint.Core.Bll.Commands.Quotes;
using WaterPoint.Core.Bll.Commands.QuoteTasks;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.Bll.Queries.JobTimesheet;
using WaterPoint.Core.Bll.Queries.QuoteTasks;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Contracts.JobTimesheet;
using WaterPoint.Core.Domain.Contracts.QuoteTasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.JobTimesheet;
using WaterPoint.Core.Domain.QueryParameters.Quotes;
using WaterPoint.Core.Domain.QueryParameters.QuoteTasks;
using WaterPoint.Core.Domain.Requests.JobTimesheet;
using WaterPoint.Core.Domain.Requests.Quotes;
using WaterPoint.Core.Domain.Requests.QuoteTasks;
using WaterPoint.Core.RequestProcessor.Quotes;
using WaterPoint.Core.RequestProcessor.QuoteTasks;
using WaterPoint.Core.RequestProcessor.Timesheet;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.JobTimesheet;
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
            Bind<IQuery<ListQuoteTasks>>().To<ListQuoteTasksQuery>();
        }

        public void BindQueryRunners()
        {
            Bind<IPagedQueryRunner<ListQuoteTasks, QuoteTaskBasicPoco>>()
                .To<PagedQueryRunner<ListQuoteTasks, QuoteTaskBasicPoco>>();
        }

        public void BindCommands()
        {
            Bind<ICommand<CreateQuote>>().To<CreateQuoteCommand>();
            Bind<ICommand<CreateQuoteTask>>().To<CreateQuoteTaskCommand>();

        }

        public void BindCommandExecutors()
        {
            Bind<ICommandExecutor<CreateQuote>>().To<CreateCommandExecutor<CreateQuote>>();
            Bind<ICommandExecutor<CreateQuoteTask>>().To<CreateCommandExecutor<CreateQuoteTask>>();
        }

        private void BindRequestProcessors()
        {
            Bind<IWriteRequestProcessor<CreateQuoteRequest>>()
                .To<CreateQuoteProcessor>();

            Bind<IWriteRequestProcessor<CreateQuoteTaskRequest>>()
                .To<CreateQuoteTaskProcessor>();

            Bind<ISimplePagedProcessor<ListQuoteTasksRequest, QuoteTaskBasicContract>>()
                .To<ListQuoteTasksProcessor>();
        }
    }
}
