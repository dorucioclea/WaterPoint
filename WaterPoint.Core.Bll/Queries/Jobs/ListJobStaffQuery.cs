using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Jobs;
using WaterPoint.Data.Entity.Pocos.Staff;

namespace WaterPoint.Core.Bll.Queries.Jobs
{
    public class ListJobStaffQuery : IQuery<ListJobStaff, JobStaffPoco>
    {
        public void BuildQuery(ListJobStaff parameter)
        {
            Query = "[dbo].[List_JobStaff]";
            Parameters = new {organizationid = parameter.OrganizationId, jobid = parameter.JobId};
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
        public bool IsStoredProcedure => true;
    }
}
