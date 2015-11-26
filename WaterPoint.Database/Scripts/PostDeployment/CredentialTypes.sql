DECLARE @orgId INT = (SELECT Id FROM Organization WHERE Name = 'Water Point')

IF NOT EXISTS(SELECT TOP 1 * FROM dbo.CredentialType) BEGIN
        INSERT INTO dbo.CredentialType (Description) VALUES (N'员工')
        INSERT INTO dbo.CredentialType (Description) VALUES (N'客户')
    END
GO
