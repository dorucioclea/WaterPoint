using Utility;
using WaterPoint.Api.Common;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Domain.Contracts.JobTimesheet;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.JobTimesheet;
using WaterPoint.Core.Domain.Requests.JobTimesheet;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos.JobTimesheet;

namespace WaterPoint.Core.RequestProcessor.Timesheet
{
    public class ListJobTimesheetProcessor :
        SimplePagedProcessor<ListJobTimesheetRequest, ListJobTimesheet, JobTimesheetPoco, JobTimesheetBasicContract>
    {
        public ListJobTimesheetProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<ListJobTimesheet> listQuery,
            IPagedQueryRunner<ListJobTimesheet, JobTimesheetPoco> listQueryRunner,
            SimplePaginationParameterConverter converter)
            : base(dapperUnitOfWork, listQuery, listQueryRunner, converter)
        {
        }

        public override JobTimesheetBasicContract Map(JobTimesheetPoco source)
        {
            return JobTimesheetMapper.Map(source);
        }

        public override ListJobTimesheet GetParameter(ListJobTimesheetRequest input)
        {
            var parameter = Converter.Convert(input, "Id")
                .MapTo(new ListJobTimesheet());

            parameter.OrganizationId = input.OrganizationId;
            parameter.JobId = input.JobId;

            return parameter;
        }
    }
}
