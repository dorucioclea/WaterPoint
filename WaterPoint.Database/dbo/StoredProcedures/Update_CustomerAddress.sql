CREATE PROCEDURE [dbo].[Update_CustomerAddress]
    @addressid INT,
    @organizationid INT,
    @customerid INT,
    @isprimary BIT,
    @ispostaddress BIT
AS
SET NOCOUNT ON;
BEGIN

    IF (@isprimary = 1)
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
                ca.IsPrimary = 1
            FROM dbo.CustomerAddress ca
                JOIN dbo.[Address] a ON ca.AddressId = a.Id
	        WHERE
		        a.OrganizationId = @organizationid
                AND ca.CustomerId = @customerid
		        AND ca.AddressId = @addressid
        END

    IF (@ispostaddress = 1)
        BEGIN
            UPDATE ca
	        SET
                ca.IsPostAddress = 0
            FROM dbo.CustomerAddress ca
                JOIN dbo.[Address] a ON ca.AddressId = a.Id
	        WHERE
		        a.OrganizationId = @organizationid
                AND ca.CustomerId = @customerid
		        AND ca.AddressId <> @addressid

            UPDATE ca
	        SET
                ca.IsPostAddress = 1
            FROM dbo.CustomerAddress ca
                JOIN dbo.[Address] a ON ca.AddressId = a.Id
	        WHERE
		        a.OrganizationId = @organizationid
                AND ca.CustomerId = @customerid
		        AND ca.AddressId = @addressid
        END

	SELECT @@ROWCOUNT
END
GO
