using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters;

namespace WaterPoint.Core.Bll.Commands.JobCostItems
{
    public class ToggleIsDeleteJobCostItemCommand : ICommand<ToggleIsDelete>
    {
        private readonly string _sql = $@"
            UPDATE [dbo].[JobCostItem]
            SET
                [IsDeleted] = @isdeleted
            WHERE
                OrganizationId = @organizationid AND Id = @id

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
