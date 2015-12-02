using System.Linq;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.QueryRunners.TaskDefinitions
{
    public class GetTaskDefinitionByIdQueryRunner
    {
        private readonly IDapperDbContext _dapperDbContext;

        public GetTaskDefinitionByIdQueryRunner(IDapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }

        public TaskDefinition Run(IQuery query)
        {
            var taskDefinition = _dapperDbContext
                .List<TaskDefinition>(query.Query, query.Parameters)
                .SingleOrDefault();

            return taskDefinition;
        }
    }
}
