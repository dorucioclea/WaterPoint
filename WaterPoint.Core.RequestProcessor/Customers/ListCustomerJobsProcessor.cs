using System.Collections.Generic;
using System.Linq;
using Utility;
using WaterPoint.Api.Common;
using WaterPoint.Core.Bll.QueryParameters;
using WaterPoint.Core.Bll.QueryParameters.Customers;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Dtos;
using WaterPoint.Core.Domain.Dtos.Requests.Customers;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos;
using WaterPoint.Data.Entity.Pocos.Jobs;

namespace WaterPoint.Core.RequestProcessor.Customers
{
    public class ListCustomerJobsProcessor :
        IRequestProcessor<ListCustomerJobsRequest, PaginatedResult<JobWithCustomerContract>>
    {
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        private readonly PaginationQueryParameterConverter _paginationQueryParameterConverter;
        private readonly IQuery<PaginatedCustomerIdOrgId> _paginatedcustomerJobsQuery;
        private readonly IListEntitiesRunner<PaginatedCustomerIdOrgId, JobWithCustomerAndStatusPoco> _paginatedCustomerRunner;

        public ListCustomerJobsProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            PaginationQueryParameterConverter paginationQueryParameterConverter,
            IQuery<PaginatedCustomerIdOrgId> paginatedcustomerJobsQuery,
            IListEntitiesRunner<PaginatedCustomerIdOrgId, JobWithCustomerAndStatusPoco> paginatedCustomerRunner)
        {
            _dapperUnitOfWork = dapperUnitOfWork;
            _paginationQueryParameterConverter = paginationQueryParameterConverter;
            _paginatedcustomerJobsQuery = paginatedcustomerJobsQuery;
            _paginatedCustomerRunner = paginatedCustomerRunner;
        }

        public JobWithCustomerContract Map(JobWithCustomerAndStatusPoco source)
        {
            return JobMapper.Map(source);
        }

        public PaginatedResult<JobWithCustomerContract> Process(ListCustomerJobsRequest input)
        {
            var parameter = _paginationQueryParameterConverter.Convert(input.PaginationParamter, "Id")
                .MapTo(new PaginatedCustomerIdOrgId());

            parameter.OrganizationId = input.CustomerIdOrgIdRp.OrganizationId;
            parameter.CustomerId = input.CustomerIdOrgIdRp.CustomerId;

            _paginatedcustomerJobsQuery.BuildQuery(parameter);

            using (_dapperUnitOfWork.Begin())
            {
                var result = _paginatedCustomerRunner.Run(_paginatedcustomerJobsQuery);

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
