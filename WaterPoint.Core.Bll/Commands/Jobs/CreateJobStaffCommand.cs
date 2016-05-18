using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Jobs;

namespace WaterPoint.Core.Bll.Commands.Jobs
{
    public class CreateJobStaffCommand : ICommand<CreateJobStaff>
    {
        public void BuildQuery(CreateJobStaff input)
        {
            Query = "[dbo].[Add_JobStaff]";

            Parameters = new
            {
                organizationid = input.OrganizationId,
                jobid = input.JobId,
                staffid = input.StaffId
            };
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
        public bool IsStoredProcedure => true;
    }
}