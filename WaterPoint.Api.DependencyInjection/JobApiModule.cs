using System.Collections.Generic;
using Ninject.Modules;
using WaterPoint.Core.Bll.Commands.Jobs;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.Bll.Queries.Jobs;
using WaterPoint.Core.Bll.QueryParameters.Jobs;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Bll.QueryRunners.Jobs;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Dtos.Requests.Jobs;
using WaterPoint.Core.RequestProcessor;
using WaterPoint.Core.RequestProcessor.Jobs;
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
            BindCommandExecutors();
            BindQueryParameterAnalyzer();
        }

        private void BindQueries()
        {
            Bind<IListPaginatedWithOrgIdQuery<PaginatedJobsQueryParameter>>().To<ListPaginatedJobsQuery>();
            Bind<IQuery<GetJobDetailsQueryParameter>>().To<GetJobByIdQuery>();
        }

        private void BindQueryRunners()
        {
            Bind<IListPaginatedEntitiesRunner<PaginatedJobsQueryParameter, JobWithCustomerAndStatusPoco>>()
                .To<ListPaginatedJobsRunner>();

            Bind<IQueryRunner<GetJobDetailsQueryParameter, JobWithDetailsPoco>>()
                .To<GetJobByIdQueryRunner>();
        }

        public void BindCommands()
        {
            Bind<ICommand<CreateBasicJobQueryParameter>>().To<CreateBasicJobCommand>();

            //Bind<CreateCommandExecutor>().ToSelf();
            //Bind<GetJobByIdQuery>().ToSelf();
            //Bind<GetJobByIdQueryRunner>().ToSelf();
            //Bind<CreateJobsCommand>().ToSelf();
            //Bind<GetJobByIdQueryRunner>().ToSelf();
        }

        public void BindCommandExecutors()
        {
            Bind<ICommandExecutor<CreateBasicJobQueryParameter>>()
                .To<CreateCommandExecutor<CreateBasicJobQueryParameter>>();
        }

        private void BindQueryParameterAnalyzer()
        {
            Bind<PaginationQueryParameterConverter>().ToSelf();

            Bind<JobStatusQueryParameterConverter>().ToSelf();
        }

        private void BindRequestProcessors()
        {
            Bind<IRequestProcessor<ListPaginatedJobsRequest, PaginatedResult<IEnumerable<JobWithCustomerContract>>>>()
                .To<ListPaginatedJobsProcessor>();

            Bind<IRequestProcessor<CreateJobRequest, JobWithCustomerContract>>()
                .To<CreateJobProcessor>();

            Bind<IRequestProcessor<GetJobByIdRequest, JobWithDetailsContract>>().To<GetJobByIdRequestProcessor>();




            //Bind<IRequestProcessor<UpdateCustomerRequest, CustomerContract>>()
            //    .To<UpdateCustomerRequestProcessor>();
            //Bind<IRequestProcessor<GetCustomerByIdRequest, CustomerContract>>()
            //    .To<GetCustomerByIdRequestProcessor>();

        }
    }
}
