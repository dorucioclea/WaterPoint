﻿using Ninject.Modules;
using WaterPoint.Api.Common;
using WaterPoint.Core.Bll.Commands.JobTimesheet;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.Bll.Queries.JobTimesheet;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Contracts.JobTimesheet;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.JobTimesheet;
using WaterPoint.Core.Domain.Requests.JobCostItems;
using WaterPoint.Core.Domain.Requests.JobTimesheet;
using WaterPoint.Core.RequestProcessor.Timesheet;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.JobTimesheet;


namespace WaterPoint.Api.DependencyInjection
{
    public class JobTimesheetApiModule : NinjectModule
    {
        public override void Load()
        {
            BindRequestProcessors();
            BindQueries();
            BindCommands();
        }

        private void BindQueries()
        {
            Bind<IQuery<ListJobTimesheet, JobTimesheetPoco>>().To<ListJobTimesheetQuery>();
            Bind<IQuery<GetJobTimesheet, Data.Entity.DataEntities.JobTimesheet>>().To<GetJobTimesheetQuery>();
        }

        public void BindCommands()
        {
            Bind<ICommand<CreateJobTimesheet>>().To<CreateJobTimesheetCommand>();
            Bind<ICommand<UpdateJobTimesheet>>().To<UpdateJobTimesheetCommand>();
        }

        private void BindRequestProcessors()
        {
            Bind<IWriteRequestProcessor<CreateJobTimesheetRequest>>()
                    .To<CreateJobTimesheetProcessor>();

            Bind<IListProcessor<ListJobTimesheetRequest, JobTimesheetBasicContract>>()
                    .To<ListJobTimesheetProcessor>();

            Bind<IRequestProcessor<GetJobTimesheetRequest, JobTimesheetContract>>()
                .To<GetJobTimesheetProcessor>();

            Bind<IWriteRequestProcessor<UpdateJobTimesheetRequest>>()
                .To<UpdateJobTimesheetProcessor>();
        }
    }
}
