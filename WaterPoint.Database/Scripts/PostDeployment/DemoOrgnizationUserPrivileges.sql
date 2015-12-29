IF (NOT EXISTS (SELECT TOP 1 * FROM dbo.OrganizationUserPrivilege)) BEGIN
    DECLARE @ouid INT =
        (
            SELECT u.Id
            FROM dbo.OrganizationUser u
                JOIN dbo.[Credential] c
                    ON u.CredentialId = c.Id
                WHERE c.Email='hmiaosys@gmail.com')

    INSERT INTO dbo.OrganizationUserPrivilege
        (OrganizationUserId, PrivilegeId, IsFull)
    SELECT @ouid, id, 1 from privilege
END
GO
