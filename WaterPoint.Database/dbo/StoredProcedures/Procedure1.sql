CREATE PROCEDURE [dbo].[SoftDelete_Customers]
    @organizationid INT,
    @customerids VARCHAR(MAX)
AS
SET NOCOUNT ON;
BEGIN
    UPDATE c
	SET
        c.IsDeleted = 1
    FROM dbo.Customer c
        JOIN dbo.IntTextToTable(@customerids) u ON c.Id = u.Number
	WHERE
		c.OrganizationId = @organizationid
        
	SELECT @@ROWCOUNT
END
GO

