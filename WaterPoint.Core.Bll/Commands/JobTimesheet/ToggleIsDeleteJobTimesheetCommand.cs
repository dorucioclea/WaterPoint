﻿using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters;

namespace WaterPoint.Core.Bll.Commands.JobTimesheet
{
    public class ToggleIsDeleteJobTimesheetCommand : ICommand<ToggleIsDelete>
    {
        private readonly string _sql = $@"
            UPDATE
                [dbo].[JobTimesheet]
            SET
                [IsDeleted] = @isdeleted
            WHERE
                OrganizationId = @organizationid AND Id = @id";

        public void BuildQuery(ToggleIsDelete input)
        {
            Query = _sql;

            Parameters = new
            {
                organizationid = input.OrganizationId,
                id = input.Id,
                isdeleted = input.IsDelete
            };
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
        public bool IsStoredProcedure => false;
    }
}
