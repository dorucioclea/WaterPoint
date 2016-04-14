CREATE PROCEDURE [dbo].[List_JobTimesheet_By_JobId]
    @organizationId INT,
    @jobId INT
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
        jt.[IsWriteOff],
        jt.[OriginalMinutes],
        jt.[RoundedMinutes],
        jt.[ShortDescription],
        jt.[IsBillable],
        jt.[IsDuration],
        jt.[BaseRate],
        jt.[BillableRate],
        jt.[Version],
        jt.[UtcCreated],
        jt.[UtcUpdated],
        jt.[Uid]
    FROM
        [dbo].[JobTimesheet] jt
        JOIN [dbo].[JobTask] jk ON jt.JobTaskId = jk.Id
        JOIN [dbo].[Job] j ON jk.JobId = j.Id
    WHERE
        j.[OrganizationId] = @organizationId
        AND j.Id = @jobId
        AND jt.IsDeleted = 0
END
GO
