﻿using WaterPoint.Core.Domain.QueryParameters.JobTasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.JobCostItems;

namespace WaterPoint.Core.Bll.Queries.JobCostItems
{
    public class ListJobCostItemsQuery : IQuery<ListJobCostItems, JobCostItemListPoco>
    {
        private readonly string _sqlTemplate = @"
            SELECT
                jci.[Id]
                ,jci.[OrganizationId]
                ,jci.[JobId]
                ,jci.[LastChangeOrganizationUserId]
                ,jci.[CostItemId]
                ,jci.[IsWriteOff]
                ,jci.[ShortDescription]
                ,jci.[Code]
                ,jci.[UnitCost]
                ,jci.[UnitPrice]
                ,jci.[Quantity]
                ,jci.[IsBillable]
                ,jci.[IsActual]
                ,jci.[IsDeleted]
                ,jci.[Version]
                ,jci.[UtcCreated]
                ,jci.[UtcUpdated]
                ,jci.[Uid]
            FROM
                [dbo].[JobCostItem] jci
            WHERE
                jci.[JobId] = @jobid
                AND jci.[OrganizationId] = @organizationid";

        public void BuildQuery(ListJobCostItems parameter)
        {
            Query = _sqlTemplate;

            Parameters = new
            {
                organizationId = parameter.OrganizationId,
                jobId = parameter.JobId
            };
        }

        public bool IsStoredProcedure => false;
        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
