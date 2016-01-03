using System.Linq;
using Utility;
using WaterPoint.Api.Common;
using WaterPoint.Core.Domain.QueryParameters.JobTasks;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.JobTasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Requests.JobTasks;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.JobTasks;

namespace WaterPoint.Core.RequestProcessor.JobTasks
{
    public class ListJobTasksProcessor :
        ISimplePaginatedProcessor<ListJobTasksRequest, JobTaskBasicContract>
    {
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        private readonly IListQueryRunner<ListJobTasks, JobTaskBasicPoco> _paginatedJobTaskRunner;
        private readonly PaginationQueryParameterConverter _paginationQueryParameterConverter;
        private readonly IQuery<ListJobTasks> _paginatedJobTasksQuery;

        public ListJobTasksProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IListQueryRunner<ListJobTasks, JobTaskBasicPoco> paginatedJobTaskRunner,
            PaginationQueryParameterConverter paginationQueryParameterConverter,
            IQuery<ListJobTasks> paginatedJobTasksQuery)
        {
            _dapperUnitOfWork = dapperUnitOfWork;
            _paginatedJobTaskRunner = paginatedJobTaskRunner;
            _paginationQueryParameterConverter = paginationQueryParameterConverter;
            _paginatedJobTasksQuery = paginatedJobTasksQuery;
        }

        public JobTaskBasicContract Map(JobTaskBasicPoco source)
        {
            return JobTaskMapper.Map(source);
        }

        public SimplePaginatedResult<JobTaskBasicContract> Process(ListJobTasksRequest input)
        {
            var parameter = _paginationQueryParameterConverter.Convert(input, "Id")
                .MapTo(new ListJobTasks());

            parameter.OrganizationId = input.OrganizationId;
            parameter.JobId= input.JobId;

            _paginatedJobTasksQuery.BuildQuery(parameter);

            using (_dapperUnitOfWork.Begin())
            {
                var result = _paginatedJobTaskRunner.Run(_paginatedJobTasksQuery);

                return (result != null)
                    ? new SimplePaginatedResult<JobTaskBasicContract>
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
