using WaterPoint.Api.Common;
using WaterPoint.Core.Domain.QueryParameters.Shared;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain.Contracts.TaskDefinitions;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Requests.Shared;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos.TaskDefinitions;

namespace WaterPoint.Core.RequestProcessor.TaskDefinitions
{
    public class ListTaskDefinitionsProcessor :
        PagedProcessor<ListWithOrgIdRequest, PagedOrgId, TaskDefinitionBasicPoco, TaskDefinitionBasicContract>
    {
        public ListTaskDefinitionsProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<PagedOrgId> query,
            IPagedQueryRunner<PagedOrgId, TaskDefinitionBasicPoco> runner)
            : base(dapperUnitOfWork, query, runner)
        {
        }

        public override TaskDefinitionBasicContract Map(TaskDefinitionBasicPoco source)
        {
            return TaskDefinitionMapper.Map(source);
        }

        public override PagedOrgId GetParameter(ListWithOrgIdRequest input)
        {
            var parameter = new PagedOrgId();

            parameter.ConvertToPagedParameter(input, "Id");

            parameter.OrganizationId = input.OrganizationId;

            return parameter;
        }
    }
}
