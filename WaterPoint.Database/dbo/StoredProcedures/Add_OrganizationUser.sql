CREATE PROCEDURE [dbo].[Add_OrganizationUser]
    @organizationid INT,
    @credentialid INT,
	@organizationusertypeid INT

AS
SET NOCOUNT ON;
BEGIN
    IF EXISTS((SELECT TOP 1 Id FROM [dbo].[OrganizationUser]
            WHERE OrganizationId = @organizationid AND CredentialId = @credentialid))
        BEGIN
            UPDATE [dbo].[OrganizationUser]
            SET IsDeleted = 0
            WHERE OrganizationId = @organizationid AND CredentialId = @credentialid

            SELECT TOP 1 Id FROM [dbo].[OrganizationUser]
            WHERE OrganizationId = @organizationid AND CredentialId = @credentialid
        END
    ELSE
        BEGIN
            INSERT INTO [dbo].[OrganizationUser]
            ([OrganizationId], [CredentialId], [OrganizationUserTypeId])
            VALUES
            (@organizationid, @credentialid, @organizationusertypeid)

            SELECT SCOPE_IDENTITY()
        END
END
GO
