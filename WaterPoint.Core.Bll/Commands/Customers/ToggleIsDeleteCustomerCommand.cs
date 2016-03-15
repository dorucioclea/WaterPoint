using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters;

namespace WaterPoint.Core.Bll.Commands.Customers
{
    public class ToggleIsDeleteCustomerCommand : ICommand<ToggleIsDelete>
    {
        private readonly string _sql = $@"
            UPDATE
                [dbo].[Customer]
            SET
                [IsDeleted] = @isdeleted
            WHERE
                OrganizationId = @organizationid AND Id = @id";

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
