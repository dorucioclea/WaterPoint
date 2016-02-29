﻿using System.Collections.Generic;
using Ninject.Modules;
using WaterPoint.Core.Bll.Commands.Jobs;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.Bll.Queries.JobCategories;
using WaterPoint.Core.Bll.Queries.Jobs;
using WaterPoint.Core.Domain.QueryParameters.Jobs;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Contracts.JobCategories;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.JobCategories;
using WaterPoint.Core.Domain.Requests.JobCategories;
using WaterPoint.Core.Domain.Requests.Jobs;
using WaterPoint.Core.RequestProcessor;
using WaterPoint.Core.RequestProcessor.JobCategories;
using WaterPoint.Core.RequestProcessor.Jobs;
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
            BindCommands();
        }

        private void BindQueries()
        {
            Bind<IQuery<PagedJobs, JobWithCustomerAndStatusPoco>>().To<ListJobsQuery>();
            Bind<IQuery<GetJob, JobWithDetailsPoco>>().To<GetJobDetailsQuery>();
            Bind<IQuery<ListJobCategories, JobCategory>>().To<ListJobCategoriesQuery>();
        }

        public void BindCommands()
        {
            Bind<ICommand<CreateJob>>().To<CreateJobCommand>();

            Bind<ICommand<UpdateJob>>().To<UpdateJobCommand>();
        }

        private void BindRequestProcessors()
        {
            Bind<IPagedProcessor<ListJobsRequest, JobWithCustomerContract>>()
                .To<ListJobsProcessor>();

            Bind<IWriteRequestProcessor<CreateJobRequest>>()
                .To<CreateJobProcessor>();

            Bind<IRequestProcessor<GetJobByIdRequest, JobDetailsContract>>().To<GetJobByIdRequestProcessor>();

            Bind<IWriteRequestProcessor<UpdateJobRequest>>()
                .To<UpdateJobProcessor>();

            Bind<IListProcessor<ListJobCategoriesRequest, JobCategoryContract>>()
                .To<ListJobCategoriesProcessor>();

        }
    }
}
