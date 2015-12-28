CREATE PROCEDURE [dbo].[List_JobTimesheet_By_JobId]
    @organizationId INT,
    @jobId INT,
    @offset INT,
    @pageSize INT
AS
SET NOCOUNT ON;
BEGIN
    SELECT
        jt.[Id],
        jt.[JobTimesheetTypeId],
        jt.[JobTaskId],
        jt.[StaffId],
        jt.[StartDateTime],
        jt.[EndDateTime],
        jt.[OriginalMinutes],
        jt.[RoundedMinutes],
        jt.[ShortDescription],
        jt.[LongDescription],
        jt.[IsBillable],
        jt.[IsDuration],
        jt.[IsActual],
        jt.[BaseRate],
        jt.[BillableRate],
        jt.[Version],
        jt.[UtcCreated],
        jt.[UtcUpdated],
        jt.[Uid],
        [TotalCount]
    FROM
        [dbo].[JobTimesheet] jt
        JOIN [dbo].[JobTask] jk ON jt.JobTaskId = jk.Id
        JOIN [dbo].[Job] j ON jk.JobId = j.Id
        CROSS APPLY(
            SELECT COUNT(*) TotalCount
            FROM
                [dbo].[JobTimesheet] jt
                JOIN [dbo].[JobTask] jk ON jt.JobTaskId = jk.Id
                JOIN [dbo].[Job] j ON jk.JobId = j.Id
            WHERE
                j.[OrganizationId] = @organizationId
                AND j.Id = @jobId
                AND jt.IsDeleted = 0
        )[Count]

    WHERE
        j.[OrganizationId] = @organizationId
        AND j.Id = @jobId
        AND jt.IsDeleted = 0

    ORDER BY jt.Id DESC

    OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY
END
GO
