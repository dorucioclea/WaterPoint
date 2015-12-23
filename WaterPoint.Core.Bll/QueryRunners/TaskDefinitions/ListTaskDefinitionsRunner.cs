﻿using System;
using System.Collections.Generic;
using System.Linq;
using WaterPoint.Core.Domain.QueryParameters.Shared;
using WaterPoint.Core.Domain.QueryParameters.TaskDefinitions;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos;

namespace WaterPoint.Core.Bll.QueryRunners.TaskDefinitions
{
    public class ListTaskDefinitionsRunner : IListEntitiesRunner<PaginatedOrgId, TaskDefinition>
    {
        private readonly IDapperDbContext _dapperDbContext;

        public ListTaskDefinitionsRunner(IDapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }

        public PaginatedPoco<IEnumerable<TaskDefinition>> Run(IQuery<PaginatedOrgId> query)
        {
            var rawResults = _dapperDbContext
                .List<TaskDefinition, PaginatedPoco>(
                    query.Query,
                    PaginatedPoco.SplitOnColumn,
                    query.Parameters)
                .ToArray();

            if (!rawResults.Any())
                return null;

            var result = new PaginatedPoco<IEnumerable<TaskDefinition>>
            {
                TotalCount = rawResults.First().Item2.TotalCount,
                Data = rawResults.Select(i => i.Item1)
            };

            return result;
        }
    }
}
