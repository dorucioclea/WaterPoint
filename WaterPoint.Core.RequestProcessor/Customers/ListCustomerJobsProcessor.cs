using System.Collections.Generic;
using System.Linq;
using Utility;
using WaterPoint.Api.Common;
using WaterPoint.Core.Domain.QueryParameters;
using WaterPoint.Core.Domain.QueryParameters.Customers;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Db;

using WaterPoint.Core.Domain.Requests.Customers;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos;
using WaterPoint.Data.Entity.Pocos.Jobs;

namespace WaterPoint.Core.RequestProcessor.Customers
{
    public class ListCustomerJobsProcessor :
        IRequestProcessor<ListCustomerJobsRequest, SimplePaginatedResult<JobWithStatusContract>>
    {
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        private readonly PaginationQueryParameterConverter _paginationQueryParameterConverter;
        private readonly IQuery<ListCustomerJobs> _paginatedcustomerJobsQuery;
        private readonly IListQueryRunner<ListCustomerJobs, JobWithStatusPoco> _paginatedCustomerRunner;

        public ListCustomerJobsProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            PaginationQueryParameterConverter paginationQueryParameterConverter,
            IQuery<ListCustomerJobs> paginatedcustomerJobsQuery,
            IListQueryRunner<ListCustomerJobs, JobWithStatusPoco> paginatedCustomerRunner)
        {
            _dapperUnitOfWork = dapperUnitOfWork;
            _paginationQueryParameterConverter = paginationQueryParameterConverter;
            _paginatedcustomerJobsQuery = paginatedcustomerJobsQuery;
            _paginatedCustomerRunner = paginatedCustomerRunner;
        }

        public JobWithStatusContract Map(JobWithStatusPoco source)
        {
            return JobMapper.Map(source);
        }

        public SimplePaginatedResult<JobWithStatusContract> Process(ListCustomerJobsRequest input)
        {
            var parameter = _paginationQueryParameterConverter.Convert(input.Pagination, "Id")
                .MapTo(new ListCustomerJobs());

            parameter.OrganizationId = input.Parameter.OrganizationId;
            parameter.CustomerId = input.Parameter.CustomerId;

            _paginatedcustomerJobsQuery.BuildQuery(parameter);

            using (_dapperUnitOfWork.Begin())
            {
                var result = _paginatedCustomerRunner.Run(_paginatedcustomerJobsQuery);

                return (result != null)
                    ? new SimplePaginatedResult<JobWithStatusContract>
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
