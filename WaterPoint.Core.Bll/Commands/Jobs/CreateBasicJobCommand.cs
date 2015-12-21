﻿using System.Windows.Input;
using WaterPoint.Core.Bll.QueryParameters;
using WaterPoint.Core.Bll.QueryParameters.Jobs;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Commands.Jobs
{
    public class CreateBasicJobCommand : ICommand<CreateBasicJob>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public CreateBasicJobCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(CreateBasicJob parameter)
        {
            var builder = _sqlBuilderFactory.Create<CreateSqlBuilder<Job>>();

            builder.Analyze<CreateBasicJob>();
            builder.AddValueParameters(parameter);

            var sql = builder.GetSql();

            Query = sql;
            Parameters = builder.Parameters;
        }
        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}