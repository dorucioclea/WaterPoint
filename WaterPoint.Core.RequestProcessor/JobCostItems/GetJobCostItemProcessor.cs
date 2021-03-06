﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Contracts.JobCostItems;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.CostItems;
using WaterPoint.Core.Domain.QueryParameters.JobCostItems;
using WaterPoint.Core.Domain.Requests.JobCostItems;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.JobCostItems
{
    public class GetJobCostItemProcessor :
        BaseDapperUowRequestProcess,
        IRequestProcessor<GetJobCostItemRequest, JobCostItemContract>
    {
        private readonly IQuery<GetJobCostItem, JobCostItem> _query;
        private readonly IQueryRunner _runner;

        public GetJobCostItemProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<GetJobCostItem, JobCostItem> query,
            IQueryRunner runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public JobCostItemContract Process(GetJobCostItemRequest input)
        {
            var parameter = new GetJobCostItem
            {
                OrganizationId = input.OrganizationId,

                JobId = input.JobId,

                Id = input.Id
            };

            _query.BuildQuery(parameter);

            using (DapperUnitOfWork.Begin())
            {
                var entity = _runner.Run(_query);

                var result = JobCostItemMapper.Map(entity);

                return result;
            }


        }
    }
}
