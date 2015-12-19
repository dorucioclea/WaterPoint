using System.Collections.Generic;
using Ninject.Modules;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.Bll.Queries.Jobs;
using WaterPoint.Core.Bll.QueryParameters;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Bll.QueryRunners.Jobs;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Dtos.Requests.Jobs;
using WaterPoint.Core.Domain.Dtos.Requests.Shared;
using WaterPoint.Core.RequestProcessor;
using WaterPoint.Core.RequestProcessor.Jobs;
using WaterPoint.Core.RequestProcessor.JobTasks;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.Jobs;

namespace WaterPoint.Api.DependencyInjection
{
    public class JobApiModule : NinjectModule
    {
        public override void Load()
        {
            BindRequestProcessors();
            BindQueries();
            BindQueryRunners();
            BindCommands();
            BindQueryParameterAnalyzer();
        }

        private void BindQueries()
        {
            Bind<IListPaginatedWithOrgIdQuery<PaginatedJobsQueryParameter>>().To<ListPaginatedJobsQuery>();
        }

        private void BindQueryRunners()
        {
            Bind<IListPaginatedEntitiesRunner<JobWithCustomerAndStatusPoco>>().To<ListPaginatedJobsRunner>();
        }

        public void BindCommands()
        {
            //Bind<CreateCommandExecutor>().ToSelf();
            //Bind<GetJobByIdQuery>().ToSelf();
            //Bind<GetJobByIdQueryRunner>().ToSelf();
            //Bind<CreateJobsCommand>().ToSelf();
            //Bind<GetJobByIdQueryRunner>().ToSelf();
        }

        private void BindQueryParameterAnalyzer()
        {
            Bind<PaginationQueryParameterConverter>().ToSelf();

            Bind<JobStatusQueryParameterConverter>().ToSelf();
        }

        private void BindRequestProcessors()
        {
            Bind<IRequestProcessor<ListPaginatedJobsRequest, PaginatedResult<IEnumerable<JobWithCustomerAndStatusContract>>>>()
                .To<ListPaginatedJobsProcessor>();

            Bind<IRequestProcessor<CreateJobRequest, JobWithCustomerAndStatusContract>>()
                .To<CreateJobRequestProcessor>();

            //Bind<IRequestProcessor<GetJobByIdRequest, JobContract>>().To<GetJobByIdRequestProcessor>();




            //Bind<IRequestProcessor<UpdateCustomerRequest, CustomerContract>>()
            //    .To<UpdateCustomerRequestProcessor>();
            //Bind<IRequestProcessor<GetCustomerByIdRequest, CustomerContract>>()
            //    .To<GetCustomerByIdRequestProcessor>();

        }
    }
}
