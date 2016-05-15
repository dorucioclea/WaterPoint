CREATE PROCEDURE [dbo].[List_JobTimesheet_By_JobId]
    @organizationId INT,
    @jobId INT
AS
SET NOCOUNT ON;
BEGIN
    SELECT
        jt.[Id]
        ,jt.[OrganizationId]
        ,jt.[JobId]
        ,jt.[JobTimesheetTypeId]
        ,jt.[LastChangeOrganizationUserId]
        ,jt.[JobTaskId]
        ,jt.[IsWriteOff]
        ,jt.[StaffId]
        ,jt.[StartDateTime]
        ,jt.[EndDateTime]
        ,jt.[OriginalMinutes]
        ,jt.[RoundedMinutes]
        ,jt.[ShortDescription]
        ,jt.[IsBillable]
        ,jt.[BaseRate]
        ,jt.[BillableRate]
        ,jt.[IsDuration]
        ,jt.[IsDeleted]
        ,jt.[Version]
        ,jt.[UtcCreated]
        ,jt.[UtcUpdated]
        ,jt.[Uid]
    FROM
        [dbo].[JobTimesheet] jt
    WHERE
        jt.[OrganizationId] = @organizationId
        AND jt.Id = @jobId
        AND jt.IsDeleted = 0
END
GO
