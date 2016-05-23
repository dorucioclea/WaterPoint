using Ninject.Modules;
using WaterPoint.Core.Bll.Commands.JobTimesheet;
using WaterPoint.Core.Bll.Queries.JobTimesheet;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.JobTimesheet;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters;
using WaterPoint.Core.Domain.QueryParameters.JobTimesheet;
using WaterPoint.Core.Domain.Requests;
using WaterPoint.Core.Domain.Requests.JobTimesheet;
using WaterPoint.Core.RequestProcessor.Timesheet;
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
            Bind<ICommand<ToggleIsDelete>>().To<ToggleIsDeleteJobTimesheetCommand>()
                .WhenInjectedExactlyInto<DeleteJobTimesheetProcessor>();
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

            Bind<IDeleteRequestProcessor<OrganizationEntityRequest>>()
                .To<DeleteJobTimesheetProcessor>().WhenParentNamed("JobTimesheetController");
        }
    }
}
