using System.Linq;
using Utility;
using WaterPoint.Api.Common;
using WaterPoint.Core.Bll.QueryParameters.JobTasks;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.JobTasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Dtos.Requests.JobTasks;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.JobTasks
{
    public class ListJobTasksProcessor :
        IRequestProcessor<ListJobTasksRequest, PaginatedResult<JobTaskContract>>
    {
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        private readonly IListEntitiesRunner<ListJobTasks, JobTask> _paginatedJobTaskRunner;
        private readonly PaginationQueryParameterConverter _paginationQueryParameterConverter;
        private readonly IQuery<ListJobTasks> _paginatedJobTasksQuery;

        public ListJobTasksProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IListEntitiesRunner<ListJobTasks, JobTask> paginatedJobTaskRunner,
            PaginationQueryParameterConverter paginationQueryParameterConverter,
            IQuery<ListJobTasks> paginatedJobTasksQuery)
        {
            _dapperUnitOfWork = dapperUnitOfWork;
            _paginatedJobTaskRunner = paginatedJobTaskRunner;
            _paginationQueryParameterConverter = paginationQueryParameterConverter;
            _paginatedJobTasksQuery = paginatedJobTasksQuery;
        }

        public JobTaskContract Map(JobTask source)
        {
            return JobTaskMapper.Map(source);
        }

        public PaginatedResult<JobTaskContract> Process(ListJobTasksRequest input)
        {
            var parameter = _paginationQueryParameterConverter.Convert(input.Pagination, "Id")
                .MapTo(new ListJobTasks());

            parameter.OrganizationId = input.Parameter.OrganizationId;
            parameter.JobId= input.Parameter.JobId;

            _paginatedJobTasksQuery.BuildQuery(parameter);

            using (_dapperUnitOfWork.Begin())
            {
                var result = _paginatedJobTaskRunner.Run(_paginatedJobTasksQuery);

                return (result != null)
                    ? new PaginatedResult<JobTaskContract>
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
