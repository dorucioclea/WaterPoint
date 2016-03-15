CREATE PROCEDURE [dbo].[BulkDelete_CostItems]
     @organizationid INT,
     @costitemids VARCHAR(MAX)
 AS
 SET NOCOUNT ON;
 BEGIN
	UPDATE c
 	SET
         c.IsDeleted = 1
    FROM dbo.CostItem c
		JOIN dbo.IntTextToTable(@costitemids) u ON c.Id = u.Number
 	WHERE
 		c.OrganizationId = @organizationid
         
 	SELECT @@ROWCOUNT
 END
 GO