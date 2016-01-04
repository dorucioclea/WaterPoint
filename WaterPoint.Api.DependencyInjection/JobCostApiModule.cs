using Ninject.Modules;
using WaterPoint.Core.Bll.Commands.JobCostItems;
using WaterPoint.Core.Bll.Commands.Jobs;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.Bll.Queries.JobCostItems;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Contracts.JobCostItems;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.JobCostItems;
using WaterPoint.Core.Domain.QueryParameters.Jobs;
using WaterPoint.Core.Domain.QueryParameters.JobTasks;
using WaterPoint.Core.Domain.Requests.JobCostItems;
using WaterPoint.Core.Domain.Requests.Jobs;
using WaterPoint.Core.RequestProcessor.JobCostItems;
using WaterPoint.Core.RequestProcessor.Jobs;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.JobCostItems;

namespace WaterPoint.Api.DependencyInjection
{
    public class JobCostApiModule : NinjectModule
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
            Bind<IQuery<ListJobCostItems>>().To<ListJobCostItemsQuery>();
            Bind<IQuery<GetJobCostItem>>().To<GetJobCostItemQuery>();
        }

        public void BindQueryRunners()
        {
            Bind<IPagedQueryRunner<ListJobCostItems, JobCostItemListPoco>>()
                .To<PagedQueryRunner<ListJobCostItems, JobCostItemListPoco>>();
            Bind<IQueryRunner<GetJobCostItem, JobCostItem>>().To<QueryRunner<GetJobCostItem, JobCostItem>>();
        }

        public void BindCommands()
        {
            Bind<ICommand<CreateJobCostItem>>().To<CreateJobCostItemCommand>();

            Bind<ICommand<UpdateJobCostItem>>().To<UpdateJobCostItemCommand>();
        }

        public void BindCommandExecutors()
        {
            Bind<ICommandExecutor<CreateJobCostItem>>().To<CreateCommandExecutor<CreateJobCostItem>>();

            Bind<ICommandExecutor<UpdateJobCostItem>>().To<UpdateCommandExecutor<UpdateJobCostItem>>();
        }

        private void BindRequestProcessors()
        {
            Bind<IWriteRequestProcessor<CreateJobCostItemRequest>>()
                .To<CreateJobCostItemProcessor>();

            Bind<ISimplePagedProcessor<ListJobCostItemsRequest, JobCostItemBasicContract>>()
                .To<ListJobCostItemsProcessor>();

            Bind<IRequestProcessor<GetJobCostItemRequest, JobCostItemContract>>()
                .To<GetJobCostItemProcessor>();

            Bind<IWriteRequestProcessor<UpdateJobCostItemRequest>>()
                .To<UpdateJobCostItemProcessor>();
        }
    }
}
