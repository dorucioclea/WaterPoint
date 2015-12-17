using System.Collections.Generic;
using System.Linq;
using Utility;
using WaterPoint.Core.Bll.QueryParameters;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.ContractMapper;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Dtos.Parameters;
using WaterPoint.Core.Domain.Dtos.Requests.Jobs;
using WaterPoint.Core.Domain.Dtos.Requests.Shared;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Jobs
{
    //public JobStatusAna

    public class ListPaginatedJobsProcessor :
        IRequestProcessor<ListPaginatedJobsRequest, PaginatedResult<IEnumerable<JobContract>>>
    {
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        private readonly IListPaginatedEntitiesRunner<Job> _paginatedJobRunner;
        private readonly PaginationQueryParameterConverter _paginationQueryParameterConverter;
        private readonly JobStatusQueryParameterConverter _jobStatusQueryParameterConverter;
        private readonly IListPaginatedWithOrgIdQuery<PaginatedJobsQueryParameter> _paginatedJobsQuery;

        public ListPaginatedJobsProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IListPaginatedEntitiesRunner<Job> paginatedJobRunner,
            PaginationQueryParameterConverter paginationQueryParameterConverter,
            JobStatusQueryParameterConverter jobStatusQueryParameterConverter,
            IListPaginatedWithOrgIdQuery<PaginatedJobsQueryParameter> paginatedJobsQuery)
        {
            _dapperUnitOfWork = dapperUnitOfWork;
            _paginatedJobRunner = paginatedJobRunner;
            _paginationQueryParameterConverter = paginationQueryParameterConverter;
            _jobStatusQueryParameterConverter = jobStatusQueryParameterConverter;
            _paginatedJobsQuery = paginatedJobsQuery;
        }

        public JobContract Map(Job source)
        {
            return JobMapper.Map(source);
        }

        public PaginatedResult<IEnumerable<JobContract>> Process(ListPaginatedJobsRequest input)
        {
            var parameter = new PaginatedJobsQueryParameter();

            _paginationQueryParameterConverter.Convert(input.PaginationParamter, "Id")
                .MapTo(parameter);

            _jobStatusQueryParameterConverter.Convert(input.JobStatusParameter)
                .MapTo(parameter);

            _paginatedJobsQuery.BuildQuery(parameter);

            using (_dapperUnitOfWork.Begin())
            {
                var result = _paginatedJobRunner.Run(_paginatedJobsQuery);

                return (result != null)
                    ? new PaginatedResult<IEnumerable<JobContract>>
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
