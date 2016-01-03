using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;
using WaterPoint.Api.Common;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.JobTimesheet;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.JobTimesheet;
using WaterPoint.Core.Domain.QueryParameters.Shared;
using WaterPoint.Core.Domain.Requests.JobTimesheet;
using WaterPoint.Core.Domain.Requests.Shared;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.JobTimesheet;

namespace WaterPoint.Core.RequestProcessor.Timesheet
{
    public class ListJobTimesheetProcessor :
         ISimplePaginatedProcessor<ListJobTimesheetRequest, JobTimesheetBasicContract>
    {
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        private readonly IListQueryRunner<ListJobTimesheet, JobTimesheetPoco> _paginatedJobTimesheetRunner;
        private readonly PaginationQueryParameterConverter _paginationQueryParameterConverter;
        private readonly IQuery<ListJobTimesheet> _paginatedJobTimesheetsQuery;

        public ListJobTimesheetProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IListQueryRunner<ListJobTimesheet, JobTimesheetPoco> paginatedJobTimesheetRunner,
            PaginationQueryParameterConverter paginationQueryParameterConverter,
            IQuery<ListJobTimesheet> paginatedJobTimesheetsQuery)
        {
            _dapperUnitOfWork = dapperUnitOfWork;
            _paginatedJobTimesheetRunner = paginatedJobTimesheetRunner;
            _paginationQueryParameterConverter = paginationQueryParameterConverter;
            _paginatedJobTimesheetsQuery = paginatedJobTimesheetsQuery;
        }

        public JobTimesheetBasicContract Map(JobTimesheetPoco source)
        {
            return JobTimesheetMapper.Map(source);
        }

        public ListJobTimesheet AnalyzeParameter(ListJobTimesheetRequest input)
        {
            var parameter = _paginationQueryParameterConverter.Convert(input, "Id")
                .MapTo(new ListJobTimesheet());

            parameter.OrganizationId = input.OrganizationId;
            parameter.JobId = input.JobId;

            return parameter;
        }

        public SimplePaginatedResult<JobTimesheetBasicContract> Process(ListJobTimesheetRequest input)
        {
            var parameter = AnalyzeParameter(input);

            _paginatedJobTimesheetsQuery.BuildQuery(parameter);

            using (_dapperUnitOfWork.Begin())
            {
                var result = _paginatedJobTimesheetRunner.Run(_paginatedJobTimesheetsQuery);

                return (result != null)
                    ? new SimplePaginatedResult<JobTimesheetBasicContract>
                    {
                        Data = result.Data.Select(Map),
                        TotalCount = result.TotalCount,
                        PageNumber = _paginationQueryParameterConverter.PageNumber,
                        PageSize = _paginationQueryParameterConverter.PageSize
                    }
                    : null;
            }
        }
    }
}
