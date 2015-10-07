/* Organization */
IF (NOT EXISTS(SELECT TOP 1 * FROM Organization)) BEGIN
    INSERT INTO dbo.Organization (Name, CountryId, IsActive) VALUES ('Water Point', 1, 1)
END
GO

/* Branch */
IF (NOT EXISTS(SELECT TOP 1 * FROM Branch))
BEGIN
    INSERT INTO dbo.Branch (Name, IsActive, IsMainBranch, OrganizationId) VALUES ('Water Point', 1, 1, (SELECT Id FROM dbo.Organization WHERE name = 'Water Point'))
END
GO

/* Customers */
DECLARE @orgId INT = (SELECT Id FROM dbo.Organization WHERE Name = 'Water Point')
DECLARE @counter INT = 0

IF (NOT EXISTS (SELECT TOP 1 * FROM dbo.Customer)) BEGIN
    WHILE @counter < 10 BEGIN
        INSERT INTO dbo.Customer([OrganizationId], [FirstName], [LastName])
        VALUES
        (@orgId, 'Customer ' + CONVERT(VARCHAR, @counter) + ' First name', 'Customer ' + CONVERT(VARCHAR, @counter) + ' Last name')

        SET @counter = @counter + 1
    END
END
GO
