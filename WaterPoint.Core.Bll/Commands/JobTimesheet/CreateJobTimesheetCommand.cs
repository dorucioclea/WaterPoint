using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.JobTimesheet;

namespace WaterPoint.Core.Bll.Commands.JobTimesheet
{
    public class CreateJobTimesheetCommand: ICommand<CreateJobTimesheet>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public CreateJobTimesheetCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(CreateJobTimesheet input)
        {
            var builder = _sqlBuilderFactory.Create<CreateSqlBuilder<Data.Entity.DataEntities.JobTimesheet>>();

            builder.Analyze<CreateJobTimesheet>();
            builder.AddValueParameters(input);

            var sql = builder.GetSql();

            Query = sql;
            Parameters = builder.Parameters;
        }
        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
