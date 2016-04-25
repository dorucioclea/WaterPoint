using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters;

namespace WaterPoint.Core.Bll.Commands.JobTasks
{
    public class ToggleIsDeleteJobTaskCommand : ICommand<ToggleIsDelete>
    {
        private readonly string _sql = $@"
            UPDATE jt                
            SET
                jt.[IsDeleted] = @isdeleted
            FROM
                [dbo].[JobTask] jt JOIN [dbo].[Job] j ON jt.JobId = j.Id
            WHERE
                j.OrganizationId = @organizationid AND jt.Id = @id

            SELECT @@ROWCOUNT";

        public void BuildQuery(ToggleIsDelete parameter)
        {
            Query = _sql;

            Parameters = new
            {
                organizationid = parameter.OrganizationId,
                id = parameter.Id,
                isdeleted = parameter.IsDelete
            };
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
        public bool IsStoredProcedure => false;
    }
}
