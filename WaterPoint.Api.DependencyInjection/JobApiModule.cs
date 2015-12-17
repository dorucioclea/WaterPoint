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
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Api.DependencyInjection
{
    public class JobApiModule : NinjectModule
    {
        public override void Load()
        {
            BindRequestProcessors();
            BindQueriesAndCommands();
        }

        private void BindQueriesAndCommands()
        {
            Bind<IListPaginatedWithOrgIdQuery<PaginatedWithOrgIdQueryParameter>>()
                .To<ListPaginatedJobsQuery>()
                .WhenInjectedExactlyInto<ListPaginatedJobsProcessor>();

            Bind<IListPaginatedEntitiesRunner<Job>>().To<ListPaginatedJobsRunner>();

            Bind<PaginationQueryParameterConverter>().ToSelf();

            Bind<JobStatusQueryParameterConverter>().ToSelf();

            Bind<CreateCommandExecutor>().ToSelf();
            Bind<GetJobByIdQuery>().ToSelf();
            Bind<GetJobByIdQueryRunner>().ToSelf();
            //Bind<CreateJobsCommand>().ToSelf();
            //Bind<GetJobByIdQueryRunner>().ToSelf();
        }

        private void BindRequestProcessors()
        {
            Bind<IRequestProcessor<ListPaginatedJobsRequest, PaginatedResult<IEnumerable<JobContract>>>>()
                .To<ListPaginatedJobsProcessor>();


            Bind<IRequestProcessor<GetJobByIdRequest, JobContract>>().To<GetJobByIdRequestProcessor>();


            //Bind<IRequestProcessor<CreateCustomerRequest, CustomerContract>>()
            //     .To<CreateCustomerRequestProcessor>();
            //Bind<IRequestProcessor<UpdateCustomerRequest, CustomerContract>>()
            //    .To<UpdateCustomerRequestProcessor>();
            //Bind<IRequestProcessor<GetCustomerByIdRequest, CustomerContract>>()
            //    .To<GetCustomerByIdRequestProcessor>();

        }
    }
}
