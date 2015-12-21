//using WaterPoint.Core.Domain;
//using WaterPoint.Data.Entity.DataEntities;

//namespace WaterPoint.Core.Bll.Queries.JobTasks
//{
//    public class GetJobTaskByIdQuery : IQuery
//    {
//        private readonly ISqlBuilderFactory _sqlBuilderFactory;

//        private readonly string _sqlTemplate = $@"
//                SELECT
//                    {SqlPatterns.Columns}
//                FROM
//                    {SqlPatterns.FromTable}
//                WHERE
//                   {SqlPatterns.Where}";

//        public GetJobTaskByIdQuery(ISqlBuilderFactory sqlBuilderFactory)
//        {
//            _sqlBuilderFactory = sqlBuilderFactory;
//        }

//        public void BuildQuery(int jobTaskId)
//        {
//            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

//            builder.AddTemplate(_sqlTemplate);
//            builder.AddColumns<JobTask>();
//            builder.AddConditions<JobTask>(i => i.Id == jobTaskId);

//            var sql = builder.GetSql();

//            Query = sql;

//            Parameters = new
//            {
//                jobTaskId
//            };
//        }

//        public string Query { get; private set; }
//        public object Parameters { get; private set; }
//    }
//}
