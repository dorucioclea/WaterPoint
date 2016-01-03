using System.Collections.Generic;
using System.Linq;
using Utility;
using WaterPoint.Api.Common;
using WaterPoint.Core.Domain.QueryParameters.Shared;
using WaterPoint.Core.Domain.QueryParameters.TaskDefinitions;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.TaskDefinitions;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Requests.Shared;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.TaskDefinitions
{
    public class ListTaskDefinitionsProcessor :
        IPaginatedProcessor<ListWithOrgIdRequest, TaskDefinitionContract>
    {
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        private readonly IListQueryRunner<PaginatedOrgId, TaskDefinition> _paginatedTaskDefinitionRunner;
        private readonly PaginationQueryParameterConverter _paginationQueryParameterConverter;
        private readonly IQuery<PaginatedOrgId> _paginatedTaskDefinitionsQuery;

        public ListTaskDefinitionsProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IListQueryRunner<PaginatedOrgId, TaskDefinition> paginatedTaskDefinitionRunner,
            PaginationQueryParameterConverter paginationQueryParameterConverter,
            IQuery<PaginatedOrgId> paginatedTaskDefinitionsQuery)
        {
            _dapperUnitOfWork = dapperUnitOfWork;
            _paginatedTaskDefinitionRunner = paginatedTaskDefinitionRunner;
            _paginationQueryParameterConverter = paginationQueryParameterConverter;
            _paginatedTaskDefinitionsQuery = paginatedTaskDefinitionsQuery;
        }

        public TaskDefinitionContract Map(TaskDefinition source)
        {
            return TaskDefinitionMapper.Map(source);
        }

        public PaginatedOrgId AnalyzeParameter(ListWithOrgIdRequest input)
        {
            var parameter = _paginationQueryParameterConverter.Convert(input, "Id")
                .MapTo(new PaginatedOrgId());

            parameter.OrganizationId = input.OrganizationId;

            return parameter;
        }

        public PaginatedResult<TaskDefinitionContract> Process(ListWithOrgIdRequest input)
        {
            var parameter = AnalyzeParameter(input);

            _paginatedTaskDefinitionsQuery.BuildQuery(parameter);

            using (_dapperUnitOfWork.Begin())
            {
                var result = _paginatedTaskDefinitionRunner.Run(_paginatedTaskDefinitionsQuery);

                return (result != null)
                    ? new PaginatedResult<TaskDefinitionContract>
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
