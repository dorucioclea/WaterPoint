CREATE PROCEDURE [dbo].[List_JobStaff]
    @organizationid INT,
    @jobid INT
AS

SET NOCOUNT ON;
BEGIN
    SELECT
        [Id]
        ,[OrganizationId]
        ,[OrganizationUserId]
        ,[Gender]
        ,[Code]
        ,[ContactEmail]
        ,[BaseRate]
        ,[BillableRate]
        ,[FirstName]
        ,[LastName]
        ,[OtherName]
        ,[Phone]
        ,[MobilePhone]
        ,[Dob]
        ,[IsDeleted]
        ,[IsWorking]
        ,[Version]
        ,[UtcCreated]
        ,[UtcUpdated]
        ,[Uid]
    FROM
        [dbo].[Staff] s
        JOIN [dbo].[JobStaff] js ON s.Id = js.StaffId
    WHERE
        s.OrganizationId = @organizationid AND js.JobId = @jobid
END
GO
