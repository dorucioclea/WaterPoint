CREATE PROCEDURE [dbo].[Add_OrganizationUser_Privileges]
	@organizationid INT,
	@organizationuserid INT,
    @privilegeIds VARCHAR(MAX)
AS
SET NOCOUNT ON;
BEGIN
	MERGE INTO dbo.OrganizationUserPrivilege AS T
	USING
	(
		SELECT
			ou.Id AS OrganizationUserId,
			p.Id AS PrivilegeId
		FROM
			Privilege p
			JOIN dbo.IntTextToTable(@privilegeIds) u ON p.Id = u.Number
			JOIN dbo.OrganizationUser ou ON ou.Id =  @organizationuserid AND ou.OrganizationId = @organizationid
	) AS S

	ON
		T.OrganizationUserId = S.OrganizationUserId AND T.PrivilegeId = S.PrivilegeId

	WHEN NOT MATCHED BY TARGET THEN
		INSERT (OrganizationUserId, PrivilegeId)
		VALUES (S.OrganizationUserId, S.PrivilegeId)

	WHEN NOT MATCHED BY SOURCE THEN
		DELETE;

	SELECT @@ROWCOUNT
END
GO
