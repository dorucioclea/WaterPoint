﻿using WaterPoint.Core.Bll.QueryParameters.Jobs;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.Jobs;

namespace WaterPoint.Core.Bll.Queries.Jobs
{
    public class GetJobByIdQuery : IQuery<GetJobDetails>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        private readonly string _sqlTemplate = $@"
                SELECT
                    {SqlPatterns.Columns}
                FROM                    
                    {SqlPatterns.FromTable}
                    {SqlPatterns.Join}
                WHERE
                   {SqlPatterns.Where}";

        public GetJobByIdQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(GetJobDetails parameter)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);
            builder.AddColumns<JobWithDetailsPoco>();
            builder.AddJoin<JobWithDetailsPoco>();
            builder.AddConditions<JobWithDetailsPoco>(i => i.OrganizationId == parameter.OrganizationId && i.Id == parameter.JobId);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = new
            {
                organizationId = parameter.OrganizationId,
                jobId = parameter.JobId
            };
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
