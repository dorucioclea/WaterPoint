using System.Collections.Generic;
using System.Linq;
using Utility;
using WaterPoint.Api.Common;
using WaterPoint.Core.Domain.QueryParameters.Jobs;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Requests.Jobs;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos.Jobs;

namespace WaterPoint.Core.RequestProcessor.Jobs
{
    //public JobStatusAna

    public class ListJobsProcessor :
        IRequestProcessor<ListJobsRequest, PaginatedResult<JobWithCustomerContract>>
    {
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        private readonly IListQueryRunner<PaginatedJobs, JobWithCustomerAndStatusPoco> _paginatedJobRunner;
        private readonly PaginationQueryParameterConverter _paginationQueryParameterConverter;
        private readonly JobStatusQueryParameterConverter _jobStatusQueryParameterConverter;
        private readonly IQuery<PaginatedJobs> _paginatedJobsQuery;

        public ListJobsProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IListQueryRunner<PaginatedJobs, JobWithCustomerAndStatusPoco> paginatedJobRunner,
            PaginationQueryParameterConverter paginationQueryParameterConverter,
            JobStatusQueryParameterConverter jobStatusQueryParameterConverter,
            IQuery<PaginatedJobs> paginatedJobsQuery)
        {
            _dapperUnitOfWork = dapperUnitOfWork;
            _paginatedJobRunner = paginatedJobRunner;
            _paginationQueryParameterConverter = paginationQueryParameterConverter;
            _jobStatusQueryParameterConverter = jobStatusQueryParameterConverter;
            _paginatedJobsQuery = paginatedJobsQuery;
        }

        public JobWithCustomerContract Map(JobWithCustomerAndStatusPoco source)
        {
            return JobMapper.Map(source);
        }

        public PaginatedResult<JobWithCustomerContract> Process(ListJobsRequest input)
        {
            var parameter = new PaginatedJobs
            {
                OrganizationId = input.Parameter.OrganizationId
            };

            _paginationQueryParameterConverter.Convert(input.Pagination, "Id")
                .MapTo(parameter);

            _jobStatusQueryParameterConverter.Convert(input.Parameter)
                .MapTo(parameter);

            _paginatedJobsQuery.BuildQuery(parameter);

            using (_dapperUnitOfWork.Begin())
            {
                var result = _paginatedJobRunner.Run(_paginatedJobsQuery);

                return (result != null)
                    ? new PaginatedResult<JobWithCustomerContract>
                    {
                        Data = result.Data.Select(Map),
                        TotalCount = result.TotalCount,
                        PageNumber = _paginationQueryParameterConverter.PageNumber,
                        PageSize = _paginationQueryParameterConverter.PageSize,
                        Sort = _paginationQueryParameterConverter.Sort,
                        IsDesc = _paginationQueryParameterConverter.IsDesc
                    }
                    : null;
            }
        }
    }

}
