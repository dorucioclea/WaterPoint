CREATE PROCEDURE [dbo].[List_JobStaff]
    @organizationid INT,
    @jobid INT
AS

SET NOCOUNT ON;
BEGIN
    SELECT
        s.[Id]
		,js.[JobId]
        ,s.[OrganizationId]
        ,s.[OrganizationUserId]
        ,s.[Gender]
        ,s.[Code]
        ,s.[ContactEmail]
        ,s.[BaseRate]
        ,s.[BillableRate]
        ,s.[FirstName]
        ,s.[LastName]
        ,s.[OtherName]
        ,s.[Phone]
        ,s.[MobilePhone]
        ,s.[Dob]
        ,s.[IsDeleted]
        ,s.[IsWorking]
        ,s.[Version]
        ,s.[UtcCreated]
        ,s.[UtcUpdated]
        ,s.[Uid]
    FROM
        [dbo].[Staff] s
        JOIN [dbo].[JobStaff] js ON s.Id = js.StaffId
    WHERE
        s.OrganizationId = @organizationid AND js.JobId = @jobid
END
GO
