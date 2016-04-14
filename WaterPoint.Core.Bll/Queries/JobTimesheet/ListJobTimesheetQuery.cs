using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.JobTimesheet;
using WaterPoint.Data.Entity.Pocos.JobTimesheet;

namespace WaterPoint.Core.Bll.Queries.JobTimesheet
{
    public class ListJobTimesheetQuery : IQuery<ListJobTimesheet, JobTimesheetPoco>
    {
        private const string SqlTemplate = "[dbo].[List_JobTimesheet_By_JobId]";

        public void BuildQuery(ListJobTimesheet parameter)
        {
            Query = SqlTemplate;

            Parameters = new
            {
                jobId = parameter.JobId,
                organizationId = parameter.OrganizationId
            };
        }

        public bool IsStoredProcedure => true;
        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
