using System.Collections.Generic;
using Ninject.Modules;
using WaterPoint.Core.Bll.Commands.Jobs;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.Bll.Queries.Jobs;
using WaterPoint.Core.Bll.QueryParameters.Jobs;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Bll.QueryRunners.Jobs;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Db;
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
        }

        private void BindQueries()
        {
            Bind<IQuery<PaginatedJobs>>().To<ListJobsQuery>();
            Bind<IQuery<GetJob>>().To<GetJobDetailsQuery>();
        }

        private void BindQueryRunners()
        {
            Bind<IListEntitiesRunner<PaginatedJobs, JobWithCustomerAndStatusPoco>>()
                .To<ListJobsRunner>();

            Bind<IQueryRunner<GetJob, JobWithDetailsPoco>>()
                .To<GetJobDetailsRunner>();
        }

        public void BindCommands()
        {
            Bind<ICommand<CreateJob>>().To<CreateJobCommand>();

            Bind<ICommand<UpdateJob>>().To<UpdateJobCommand>();
        }

        public void BindCommandExecutors()
        {
            Bind<ICommandExecutor<CreateJob>>()
                .To<CreateCommandExecutor<CreateJob>>();

            Bind<ICommandExecutor<UpdateJob>>()
                .To<UpdateCommandExecutor<UpdateJob>>();
        }

        private void BindRequestProcessors()
        {
            Bind<IRequestProcessor<ListJobsRequest, PaginatedResult<JobWithCustomerContract>>>()
                .To<ListJobsProcessor>();

            Bind<IRequestProcessor<CreateJobRequest, CommandResultContract>>()
                .To<CreateJobProcessor>();

            Bind<IRequestProcessor<GetJobByIdRequest, JobDetailsContract>>().To<GetJobByIdRequestProcessor>();

            Bind<IRequestProcessor<UpdateJobRequest, CommandResultContract>>()
                .To<UpdateJobRequestProcessor>();

        }
    }
}
