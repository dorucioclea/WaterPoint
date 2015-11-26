/* Customer */
/* Customers */
DECLARE @orgId INT = (SELECT Id FROM dbo.Organization WHERE Name = 'Water Point')
DECLARE @counter INT = 0

IF (NOT EXISTS (SELECT TOP 1 * FROM dbo.Customer)) BEGIN
    WHILE @counter < 10 BEGIN
        INSERT INTO dbo.Customer([OrganizationId], [FirstName], [LastName])
        VALUES
        (@orgId, N'客户 ' + CONVERT(VARCHAR, @counter) + N' 名', N'客户 ' + CONVERT(VARCHAR, @counter) + N' 姓')

        SET @counter = @counter + 1
    END
END




INSERT INTO dbo.Credential
(OrganizationId, CredentialTypeId, Email, Password)
VALUES
(@orgId, 3, 'hmiaosys@gmail.com', 'password')


INSERT INTO dbo.Job
(OrganizationId, JobStatusId, Code,ShortDescription, LongDescription, CustomerId, StartDate, EndDate, UpdatedByStaffId)
VALUES
(@orgId, 101,'GZ10000', N'改革开放后，中国的50个经典瞬间', N'热点：10岁华裔女孩要修改美国宪法，因为她要做美国总统[组图] sdfsf',10000, GETDATE(), DATEADD(DAY, 30, GETDATE()), 5)

GO

USE [WaterPoint]
GO
DECLARE @orgId INT = (SELECT Id FROM dbo.Organization WHERE Name = 'Water Point')
DECLARE @credentialId INT = (SELECT Id FROM dbo.[Credential] WHERE Email = 'hmiaosys@gmail.com')
INSERT INTO [dbo].[Staff]
           ([OrganizationId],[CredentialId],[Email],[BaseRate],[BillableRate],[FirstName],[LastName])
           
     VALUES
           (@orgId,@credentialId,'hmiaosys@gmail.com',10,20,N'淼',N'黄')
GO

