using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters;

namespace WaterPoint.Core.Bll.Commands.JobCostItems
{

    public class ToggleIsDeleteJobCostItemCommand : ICommand<ToggleIsDelete>
    {
        private readonly string _sql = $@"
            UPDATE jc                
            SET
                jc.[IsDeleted] = @isdeleted
            FROM
                [dbo].[JobCostItem] jc JOIN [dbo].[Job] j ON jc.JobId = j.JobId
            WHERE
                j.OrganizationId = @organizationid AND jc.Id = @id

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
