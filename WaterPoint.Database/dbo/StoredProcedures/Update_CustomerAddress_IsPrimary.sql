CREATE PROCEDURE [dbo].[Update_CustomerAddress_IsPrimary]
    @addressid INT,
    @organizationid INT,
    @customerid INT,
    @isprimary BIT
AS
SET NOCOUNT ON;
BEGIN
    UPDATE ca
	SET
        ca.IsPrimary = 0
    FROM dbo.CustomerAddress ca
        JOIN dbo.[Address] a ON ca.AddressId = a.Id
	WHERE
		a.OrganizationId = @organizationid
        AND ca.CustomerId = @customerid
		AND ca.AddressId <> @addressid

    UPDATE ca
	SET
        ca.IsPrimary = @isprimary
    FROM dbo.CustomerAddress ca
        JOIN dbo.[Address] a ON ca.AddressId = a.Id
	WHERE
		a.OrganizationId = @organizationid
        AND ca.CustomerId = @customerid
		AND ca.AddressId = @addressid

	SELECT @@ROWCOUNT
END
GO
