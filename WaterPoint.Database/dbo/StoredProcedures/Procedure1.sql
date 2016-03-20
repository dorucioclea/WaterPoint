CREATE PROCEDURE [dbo].[Update_CustomerContact_IsPrimary]
    @contactid INT,
    @organizationid INT,
    @customerid INT,
    @isprimary BIT
AS
SET NOCOUNT ON;
BEGIN
    IF @isprimary = 1
        BEGIN
            UPDATE cc
	        SET
                cc.IsPrimary = 0
            FROM dbo.CustomerContact cc
                JOIN dbo.[Contact] c ON cc.ContactId = c.Id
	        WHERE
		        c.OrganizationId = @organizationid
                AND cc.CustomerId = @customerid
		        AND cc.ContactId <> @contactid
        END

    UPDATE cc
	SET
        cc.IsPrimary = @isprimary
    FROM dbo.CustomerContact cc
        JOIN dbo.[Contact] c ON cc.ContactId = c.Id
	WHERE
		c.OrganizationId = @organizationid
        AND cc.CustomerId = @customerid
		AND cc.ContactId = @contactid

	SELECT @@ROWCOUNT
END
GO
