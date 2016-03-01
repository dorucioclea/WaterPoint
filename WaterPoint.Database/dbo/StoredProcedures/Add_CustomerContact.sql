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

    IF NOT EXISTS(SELECT * FROM [dbo].[CustomerContact] WHERE ContactId = @contactid AND CustomerId = @customerid)
        BEGIN
            INSERT [dbo].[CustomerContact]
	        (ContactId, CustomerId, IsPrimary)
	        VALUES
	        (@contactid, @customerid, @isprimary)

            SELECT 1;
        END
    ELSE
        BEGIN
            SELECT 0
        END
END
GO
