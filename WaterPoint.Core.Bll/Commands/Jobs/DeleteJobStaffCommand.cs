using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Jobs;

namespace WaterPoint.Core.Bll.Commands.Jobs
{
    public class DeleteJobStaffCommand : ICommand<DeleteJobStaff>
    {
        private const string Sql = "DELETE [dbo].[JobStaff] WHERE JobId = @jobid AND StaffId = @staffid SELECT @@ROWCOUNT";

        public void BuildQuery(DeleteJobStaff input)
        {
            Query = Sql;

            Parameters = new
            {
                jobid = input.JobId,
                staffid = input.StaffId
            };
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
        public bool IsStoredProcedure => false;
    }
}
