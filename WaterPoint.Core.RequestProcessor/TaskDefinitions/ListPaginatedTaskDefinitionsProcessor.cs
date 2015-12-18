using System.Collections.Generic;
using WaterPoint.Core.Bll.QueryParameters;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.RequestProcessor.Mappers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.TaskDefinitions;
using WaterPoint.Core.Domain.Dtos.Requests.Shared;
using WaterPoint.Core.RequestProcessor.Mappers;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.TaskDefinitions
{
    public class ListPaginatedTaskDefinitionsProcessor :
        IRequestProcessor<ListPaginatedWithOrgIdRequest, PaginatedResult<IEnumerable<TaskDefinitionContract>>>
    {
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        private readonly IListPaginatedEntitiesRunner<TaskDefinition> _paginatedTaskDefinitionRunner;
        private readonly PaginationQueryParameterConverter _paginationQueryParameterConverter;
        private readonly IListPaginatedWithOrgIdQuery<PaginatedWithOrgIdQueryParameter> _paginatedTaskDefinitionsQuery;

        public ListPaginatedTaskDefinitionsProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IListPaginatedEntitiesRunner<TaskDefinition> paginatedTaskDefinitionRunner,
            PaginationQueryParameterConverter paginationQueryParameterConverter,
            IListPaginatedWithOrgIdQuery<PaginatedWithOrgIdQueryParameter> paginatedTaskDefinitionsQuery)
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

        public PaginatedResult<IEnumerable<TaskDefinitionContract>> Process(ListPaginatedWithOrgIdRequest input)
        {
            throw new System.NotImplementedException();
        }
    }

}
