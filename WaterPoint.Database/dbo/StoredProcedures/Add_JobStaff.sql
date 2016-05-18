CREATE PROCEDURE [dbo].[Add_JobStaff]
    @organizationid INT,
	@jobid INT,
    @staffId INT
AS
SET NOCOUNT ON;
BEGIN
	IF(NOT EXISTS(SELECT TOP 1 * FROM dbo.JobStaff WHERE JobId = @jobid AND StaffId = @staffId))
		BEGIN 
			INSERT INTO dbo.JobStaff
			(JobId, StaffId)
			VALUES
			(@jobid, @staffId)			
		END

	SELECT @@ROWCOUNT
END
GO

