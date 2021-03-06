﻿using WaterPoint.Core.Domain.QueryParameters.JobTasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Queries.JobTasks
{
    public class GetJobTaskQuery : IQuery<GetJobTask, JobTask>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        private readonly string _sqlTemplate = $@"
                SELECT
                    {SqlPatterns.Columns}
                FROM
                    {SqlPatterns.FromTable}
                WHERE
                   {SqlPatterns.Where}";

        public GetJobTaskQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(GetJobTask parameter)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);
            builder.AddColumns<JobTask>();
            builder.AddConditions<JobTask>(
                i => i.Id == parameter.JobTaskId && i.JobId == parameter.JobId && i.IsDeleted == false);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = new
            {
                jobId = parameter.JobId,
                jobTaskId = parameter.JobTaskId
            };
        }

        public bool IsStoredProcedure => false;
        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
