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
        PagedProcessor<ListWithOrgIdRequest, PagedOrgId, TaskDefinition, TaskDefinitionContract>
    {
        public ListTaskDefinitionsProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<PagedOrgId> query,
            IPagedQueryRunner<PagedOrgId, TaskDefinition> runner)
            : base(dapperUnitOfWork, query, runner)
        {
        }

        public override TaskDefinitionContract Map(TaskDefinition source)
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
