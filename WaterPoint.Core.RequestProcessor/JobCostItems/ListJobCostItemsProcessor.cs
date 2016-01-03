using System.Linq;
using Utility;
using WaterPoint.Api.Common;
using WaterPoint.Core.Domain.QueryParameters.JobCostItems;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.JobCostItems;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.JobTasks;
using WaterPoint.Core.Domain.Requests.JobCostItems;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.JobCostItems;

namespace WaterPoint.Core.RequestProcessor.JobCostItems
{
    public class ListJobCostItemsProcessor :
        ISimplePaginatedProcessor<ListJobCostItemsRequest, JobCostItemBasicContract>
    {
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        private readonly IListQueryRunner<ListJobCostItems, JobCostItemListPoco> _paginatedJobCostRunner;
        private readonly PaginationQueryParameterConverter _paginationQueryParameterConverter;
        private readonly IQuery<ListJobCostItems> _paginatedJobCostItemsQuery;

        public ListJobCostItemsProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IListQueryRunner<ListJobCostItems, JobCostItemListPoco> paginatedJobCostRunner,
            PaginationQueryParameterConverter paginationQueryParameterConverter,
            IQuery<ListJobCostItems> paginatedJobCostItemsQuery)
        {
            _dapperUnitOfWork = dapperUnitOfWork;
            _paginatedJobCostRunner = paginatedJobCostRunner;
            _paginationQueryParameterConverter = paginationQueryParameterConverter;
            _paginatedJobCostItemsQuery = paginatedJobCostItemsQuery;
        }

        public JobCostItemBasicContract Map(JobCostItemListPoco source)
        {
            return JobCostItemMapper.Map(source);
        }

        public SimplePaginatedResult<JobCostItemBasicContract> Process(ListJobCostItemsRequest input)
        {
            var parameter = _paginationQueryParameterConverter.Convert(input, "Id")
                .MapTo(new ListJobCostItems());

            parameter.OrganizationId = input.OrganizationId;
            parameter.JobId= input.JobId;

            _paginatedJobCostItemsQuery.BuildQuery(parameter);

            using (_dapperUnitOfWork.Begin())
            {
                var result = _paginatedJobCostRunner.Run(_paginatedJobCostItemsQuery);

                return (result != null)
                    ? new SimplePaginatedResult<JobCostItemBasicContract>
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
