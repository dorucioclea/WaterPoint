DECLARE @counter INT = 0

IF (NOT EXISTS (SELECT TOP 1 * FROM dbo.Customer)) BEGIN
	DECLARE @orgId INT = (SELECT Id FROM dbo.Organization WHERE Name = 'Water Point')
    WHILE @counter < 58 BEGIN
        INSERT INTO dbo.Customer([OrganizationId], [FirstName], [LastName])
        VALUES
        (@orgId, N'客户 ' + CONVERT(VARCHAR, @counter) + N' 名', N'客户 ' + CONVERT(VARCHAR, @counter) + N' 姓')

        SET @counter = @counter + 1
    END
END
GO