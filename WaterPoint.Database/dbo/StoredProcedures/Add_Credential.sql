CREATE PROCEDURE [dbo].[Add_Credential]
    @email VARCHAR(200),
    @password VARCHAR(50)
AS
SET NOCOUNT ON;
BEGIN
    IF EXISTS((SELECT TOP 1 Id FROM [dbo].[Credential] WHERE Email = @email ))
        BEGIN
            UPDATE [dbo].[Credential]
            SET IsDeleted = 0
            WHERE Email = @email

            SELECT TOP 1 Id FROM [dbo].[Credential] WHERE Email = @email
        END
    ELSE
        BEGIN
            INSERT INTO [dbo].[Credential]
            ([Email],[Password])
            VALUES
            (@email, @password)

            SELECT SCOPE_IDENTITY()
        END
END
GO
