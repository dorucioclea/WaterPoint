using System.Collections.Generic;
using System.Linq;
using Utility;
using WaterPoint.Core.Bll.QueryParameters.TaskDefinitions;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.TaskDefinitions;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Dtos.Requests.Shared;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.TaskDefinitions
{
    public class ListPaginatedTaskDefinitionsProcessor :
        IRequestProcessor<ListPaginatedWithOrgIdRequest, PaginatedResult<IEnumerable<TaskDefinitionContract>>>
    {
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        private readonly IListPaginatedEntitiesRunner<PaginatedTaskDefinitions ,TaskDefinition> _paginatedTaskDefinitionRunner;
        private readonly PaginationQueryParameterConverter _paginationQueryParameterConverter;
        private readonly IQuery<PaginatedTaskDefinitions> _paginatedTaskDefinitionsQuery;

        public ListPaginatedTaskDefinitionsProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IListPaginatedEntitiesRunner<PaginatedTaskDefinitions, TaskDefinition> paginatedTaskDefinitionRunner,
            PaginationQueryParameterConverter paginationQueryParameterConverter,
            IQuery<PaginatedTaskDefinitions> paginatedTaskDefinitionsQuery)
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

        public PaginatedTaskDefinitions AnalyzeParameter(ListPaginatedWithOrgIdRequest input)
        {
            var parameter = _paginationQueryParameterConverter.Convert(input.PaginationParamter, "Id")
                .MapTo(new PaginatedTaskDefinitions());

            parameter.OrganizationId = input.OrganizationIdParameter.OrganizationId;

            return parameter;
        }

        public PaginatedResult<IEnumerable<TaskDefinitionContract>> Process(ListPaginatedWithOrgIdRequest input)
        {
            var parameter = AnalyzeParameter(input);

            _paginatedTaskDefinitionsQuery.BuildQuery(parameter);

            using (_dapperUnitOfWork.Begin())
            {
                var result = _paginatedTaskDefinitionRunner.Run(_paginatedTaskDefinitionsQuery);

                return (result != null)
                    ? new PaginatedResult<IEnumerable<TaskDefinitionContract>>
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
