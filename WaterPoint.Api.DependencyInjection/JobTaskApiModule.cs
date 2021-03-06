﻿using Ninject.Modules;
using WaterPoint.Core.Bll.Commands.JobTasks;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.Bll.Queries.JobTasks;
using WaterPoint.Core.Domain.QueryParameters.JobTasks;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Contracts.JobTasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters;
using WaterPoint.Core.Domain.Requests;
using WaterPoint.Core.Domain.Requests.JobTasks;
using WaterPoint.Core.RequestProcessor.JobTasks;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.JobTasks;

namespace WaterPoint.Api.DependencyInjection
{
    public class JobTaskApiModule : NinjectModule
    {
        public override void Load()
        {
            BindRequestProcessors();
            BindQueries();
            BindCommands();
        }

        private void BindQueries()
        {
            Bind<IQuery<GetJobTask, JobTask>>().To<GetJobTaskQuery>();
            Bind<IQuery<ListJobTasks, JobTaskBasicPoco>>().To<ListJobTasksQuery>();
        }

        public void BindCommands()
        {
            Bind<ICommand<CreateJobTask>>().To<CreateJobTaskCommand>();
            Bind<ICommand<UpdateJobTask>>().To<UpdateJobTaskCommand>();
            Bind<ICommand<ToggleIsDelete>>().To<ToggleIsDeleteJobTaskCommand>()
                .WhenInjectedExactlyInto<DeleteJobTaskProcessor>();
        }

        private void BindRequestProcessors()
        {
            Bind<IRequestProcessor<GetJobTaskByIdRequest, JobTaskContract>>()
                .To<GetJobTaskProcessor>();

            Bind<IWriteRequestProcessor<UpdateJobTaskRequest>>()
                .To<UpdateJobTaskProcessor>();

            Bind<IWriteRequestProcessor<CreateJobTaskRequest>>()
                .To<CreateJobTaskRequestProcessor>();

            Bind<IListProcessor<ListJobTasksRequest, JobTaskBasicContract>>()
                .To<ListJobTasksProcessor>();

            Bind<IDeleteRequestProcessor<OrganizationEntityRequest>>()
                .To<DeleteJobTaskProcessor>().Named("DeleteJobTask");
        }
    }
}
