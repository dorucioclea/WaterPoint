//using WaterPoint.Data.DbContext.Dapper;
//using WaterPoint.Data.Entity.DataEntities;

//namespace WaterPoint.Core.Bll.Commands.JobTasks
//{
//    public class CreateJobTaskCommand : ICommand
//    {
//        private readonly ISqlBuilderFactory _sqlBuilderFactory;

//        public CreateJobTaskCommand(ISqlBuilderFactory sqlBuilderFactory)
//        {
//            _sqlBuilderFactory = sqlBuilderFactory;
//        }

//        public void BuildQuery(int orgId, JobTask input)
//        {
//            var builder = _sqlBuilderFactory.Create<CreateSqlBuilder<JobTask>>();

//            builder.Analyze();
//            builder.AddValueParameters(input);

//            var sql = builder.GetSql();

//            Query = sql;
//            Parameters = builder.Parameters;
//        }
//        public string Query { get; private set; }
//        public object Parameters { get; private set; }
//    }
//}
