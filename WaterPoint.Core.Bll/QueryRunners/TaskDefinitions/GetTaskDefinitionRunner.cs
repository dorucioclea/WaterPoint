using System.Linq;
using WaterPoint.Core.Domain.QueryParameters.TaskDefinitions;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.QueryRunners.TaskDefinitions
{
    public class GetTaskDefinitionByIdQueryRunner : IQueryRunner<GetTaskDefinition, TaskDefinition>
    {
        private readonly IDapperDbContext _dapperDbContext;

        public GetTaskDefinitionByIdQueryRunner(IDapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }

        public TaskDefinition Run(IQuery<GetTaskDefinition> query)
        {
            var taskDefinition = _dapperDbContext
                .List<TaskDefinition>(query.Query, query.Parameters)
                .SingleOrDefault();

            return taskDefinition;
        }
    }
}
