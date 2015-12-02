using System.Collections.Generic;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.ContractMapper;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.TaskDefinitions;
using WaterPoint.Core.Domain.Dtos.Requests.Shared;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.TaskDefinitions
{
    public class PaginatedTaskDefinitionsProcessor : PaginatedEntitiesWithOrgIdProcessor<TaskDefinition, TaskDefinitionContract>,
        IRequestProcessor<PaginationWithOrgIdRequest, PaginatedResult<IEnumerable<TaskDefinitionContract>>>
    {
        public PaginatedTaskDefinitionsProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IPaginatedEntitiesRunner<TaskDefinition> paginatedTaskDefinitionRunner,
            PaginationAnalyzer paginationAnalyzer,
            IPaginatedWithOrgIdQuery paginatedTaskDefinitionsQuery)
            : base(dapperUnitOfWork, paginationAnalyzer, paginatedTaskDefinitionsQuery, paginatedTaskDefinitionRunner)
        {
        }

        public override TaskDefinitionContract Map(TaskDefinition source)
        {
            return TaskDefinitionMapper.Map(source);
        }
    }

}
