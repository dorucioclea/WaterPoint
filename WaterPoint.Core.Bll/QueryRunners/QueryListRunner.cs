﻿using System.Collections.Generic;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Credentials;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity;
using WaterPoint.Data.Entity.Pocos.Views;

namespace WaterPoint.Core.Bll.QueryRunners
{
    public class QueryListRunner : IQueryListRunner
    {
        private readonly IDapperDbContext _dapperDbContext;

        public QueryListRunner(IDapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }
        public IEnumerable<TOut> Run<T, TOut>(IQuery<T, TOut> query)
            where T : IQueryParameter
            where TOut : IDataEntity
        {
            return query.IsStoredProcedure
                ? _dapperDbContext.ExecuteStoredProcedure<TOut>(query.Query, query.Parameters)
                : _dapperDbContext.List<TOut>(query.Query, query.Parameters);
        }
    }
}
