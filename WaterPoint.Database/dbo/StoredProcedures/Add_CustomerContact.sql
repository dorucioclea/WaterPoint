CREATE PROCEDURE [dbo].[Add_CustomerContact]
	@customerid INT,
    @contactid INT,
    @isprimary BIT
AS
SET NOCOUNT ON;
BEGIN
	IF(@isprimary = 1)
		BEGIN
			UPDATE [dbo].[CustomerContact]
			SET IsPrimary = 0
			WHERE CustomerId = @customerid
		END

	INSERT [dbo].[CustomerContact]
	(ContactId, CustomerId, IsPrimary)
	VALUES
	(@contactid, @customerid, @isprimary)

	SELECT @@ROWCOUNT
END
GO
