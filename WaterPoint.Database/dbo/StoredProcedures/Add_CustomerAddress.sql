CREATE PROCEDURE [dbo].[Add_CustomerAddress]
	@customerid INT,
    @addressid INT,
    @isprimary BIT,
    @ispostaddress BIT
AS
SET NOCOUNT ON;
BEGIN
	IF(@isprimary = 1)
		BEGIN
			UPDATE [dbo].[CustomerAddress]
			SET IsPrimary = 0
			WHERE CustomerId = @customerid
		END

    IF(@ispostaddress = 1)
        BEGIN
            UPDATE [dbo].[CustomerAddress]
            SET IsPostAddress = 0
            WHERE CustomerId = @customerid
        END

	INSERT [dbo].[CustomerAddress]
	(AddressId, CustomerId, IsPrimary, IsPostAddress)
	VALUES
	(@addressid, @customerid, @isprimary, @ispostaddress)

	SELECT @@ROWCOUNT
END
GO
