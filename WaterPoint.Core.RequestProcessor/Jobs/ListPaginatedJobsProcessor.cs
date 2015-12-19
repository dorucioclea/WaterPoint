using System.Collections.Generic;
using System.Linq;
using Utility;
using WaterPoint.Core.Bll.QueryParameters;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Dtos.Requests.Jobs;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos.Jobs;

namespace WaterPoint.Core.RequestProcessor.Jobs
{
    //public JobStatusAna

    public class ListPaginatedJobsProcessor :
        IRequestProcessor<ListPaginatedJobsRequest, PaginatedResult<IEnumerable<JobWithCustomerAndStatusContract>>>
    {
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        private readonly IListPaginatedEntitiesRunner<JobWithCustomerAndStatusPoco> _paginatedJobRunner;
        private readonly PaginationQueryParameterConverter _paginationQueryParameterConverter;
        private readonly JobStatusQueryParameterConverter _jobStatusQueryParameterConverter;
        private readonly IListPaginatedWithOrgIdQuery<PaginatedJobsQueryParameter> _paginatedJobsQuery;

        public ListPaginatedJobsProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IListPaginatedEntitiesRunner<JobWithCustomerAndStatusPoco> paginatedJobRunner,
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

        public JobWithCustomerAndStatusContract Map(JobWithCustomerAndStatusPoco source)
        {
            return JobMapper.Map(source);
        }

        public PaginatedResult<IEnumerable<JobWithCustomerAndStatusContract>> Process(ListPaginatedJobsRequest input)
        {
            var parameter = new PaginatedJobsQueryParameter
            {
                OrganizationId = input.OrganizationIdParameter.OrganizationId
            };

            _paginationQueryParameterConverter.Convert(input.PaginationParamter, "Id")
                .MapTo(parameter);

            _jobStatusQueryParameterConverter.Convert(input.JobStatusParameter)
                .MapTo(parameter);

            _paginatedJobsQuery.BuildQuery(parameter);

            using (_dapperUnitOfWork.Begin())
            {
                var result = _paginatedJobRunner.Run(_paginatedJobsQuery);

                return (result != null)
                    ? new PaginatedResult<IEnumerable<JobWithCustomerAndStatusContract>>
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
