using System.Collections.Generic;
using Ninject.Modules;
using WaterPoint.Core.Bll;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.Bll.Queries.Jobs;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Bll.QueryRunners.Jobs;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Dtos.Shared.Requests;
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
            Bind<IPaginatedWithOrgIdQuery>()
                .To<PaginatedJobsQuery>()
                .WhenInjectedExactlyInto<PaginatedJobsProcessor>();

            Bind<IPaginatedEntitiesRunner<Job>>().To<PaginatedJobsRunner>();

            Bind<PaginationAnalyzer>().ToSelf();
            
            Bind<CreateCommandExecutor>().ToSelf();

            //Bind<CreateJobsCommand>().ToSelf();
            //Bind<GetJobByIdQueryRunner>().ToSelf();
        }

        private void BindRequestProcessors()
        {
            Bind<IRequestProcessor<PaginationWithOrgIdRequest, PaginatedResult<IEnumerable<JobContract>>>>()
                .To<PaginatedJobsProcessor>();

            //Bind<IRequestProcessor<CreateCustomerRequest, CustomerContract>>()
            //     .To<CreateCustomerRequestProcessor>();
            //Bind<IRequestProcessor<UpdateCustomerRequest, CustomerContract>>()
            //    .To<UpdateCustomerRequestProcessor>();
            //Bind<IRequestProcessor<GetCustomerByIdRequest, CustomerContract>>()
            //    .To<GetCustomerByIdRequestProcessor>();

        }
    }
}
