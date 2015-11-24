/* Organization */
IF (NOT EXISTS(SELECT TOP 1 * FROM Organization)) BEGIN
    INSERT INTO dbo.Organization (Name, CountryId, IsActive) VALUES ('Water Point', 1, 1)
END
GO
