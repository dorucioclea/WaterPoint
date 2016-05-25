using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.JobTimesheet;

namespace WaterPoint.Core.Bll.Queries.JobTimesheet
{
    public class GetJobTimesheetQuery : IQuery<GetJobTimesheet, Data.Entity.DataEntities.JobTimesheet>
    {
        private const string SqlTemplate = @"
            SELECT
		        jt.[Id],
		        jt.[OrganizationId],
		        jt.[JobId],
		        jt.[JobTimesheetTypeId],
		        jt.[LastChangeOrganizationUserId],
		        jt.[JobTaskId],
		        jt.[IsWriteOff],
		        jt.[StaffId],
		        jt.[StartDateTime],
		        jt.[EndDateTime],
		        jt.[OriginalMinutes],
		        jt.[RoundedMinutes],
		        jt.[ShortDescription],
		        jt.[LongDescription],
		        jt.[IsBillable],
		        jt.[BaseRate],
		        jt.[BillableRate],
		        jt.[IsDuration],
		        jt.[IsDeleted],
		        jt.[Version],
		        jt.[UtcCreated],
		        jt.[UtcUpdated],
		        jt.[Uid]
            FROM
                [dbo].[JobTimesheet] jt
            WHERE
                jt.[OrganizationId] = @organizationId
                AND jt.JobId = @jobId
                AND jt.Id = @id
                AND jt.IsDeleted = 0";

        public void BuildQuery(GetJobTimesheet parameter)
        {
            Query = SqlTemplate;

            Parameters = new
            {
                organizationId = parameter.OrganizationId,
                jobId = parameter.JobId,
                id = parameter.Id
            };
        }

        public bool IsStoredProcedure => false;
        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
