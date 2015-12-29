CREATE PROCEDURE [dbo].[List_Privileges_By_UserIds]
    @userIds VARCHAR(MAX)
AS
SET NOCOUNT ON;
BEGIN

    SELECT
        oup.OrganizationUserId,
        oup.PrivilegeId,
        oup.IsFull
    FROM
        dbo.OrganizationUserPrivilege oup
        JOIN Privilege p ON oup.PrivilegeId = p.Id AND p.IsDeleted = 0
        JOIN dbo.IntTextToTable(@userIds) u ON oup.OrganizationUserId = u.Number
        JOIN dbo.OrganizationUser ou ON oup.OrganizationUserId = ou.Id AND ou.IsDeleted = 0
END
GO
