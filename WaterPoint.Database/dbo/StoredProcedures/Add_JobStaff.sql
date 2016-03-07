CREATE PROCEDURE [dbo].[Add_JobStaff]
    @organizationid INT,
	@jobid INT,
    @staffids VARCHAR(MAX)
AS
SET NOCOUNT ON;
BEGIN
	MERGE INTO dbo.JobStaff AS T
	USING
	(
		SELECT
			j.Id AS JobId,
			s.Id AS StaffId
		FROM
			dbo.[Staff] s
			JOIN dbo.IntTextToTable(@staffids) u ON s.Id = u.Number AND s.OrganizationId = @organizationid
			JOIN dbo.Job j ON j.Id =  @jobid AND j.OrganizationId = @organizationid
	) AS O

	ON
		T.JobId = O.JobId AND T.StaffId = O.StaffId

	WHEN NOT MATCHED BY TARGET THEN
		INSERT (JobId, StaffId)
		VALUES (O.JobId, O.StaffId);

	SELECT @@ROWCOUNT
END
GO

