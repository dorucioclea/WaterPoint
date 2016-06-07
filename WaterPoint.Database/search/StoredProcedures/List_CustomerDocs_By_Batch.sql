CREATE PROCEDURE [dbo].[List_CustomerDocs_By_Batch]
    @lastId INT = NULL,
    @batch INT = 1000
AS
SET NOCOUNT ON;
BEGIN
    SELECT TOP (@batch)
        c.Id,
        c.OrganizationId,
        c.IsProspect,
        c.Code,
        c.FirstName,
        c.LastName,
        c.OtherName,
        c.Email
    FROM
        [dbo].[Customer] c
    WHERE
        (@lastId IS NULL OR c.Id > @lastId)
    ORDER BY 1
END
GO
