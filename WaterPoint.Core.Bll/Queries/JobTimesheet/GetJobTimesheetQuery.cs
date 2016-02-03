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
        private const string SqlTemplate = "[dbo].[Get_JobTimesheet_By_Id]";

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

        public bool IsStoredProcedure => true;
        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
