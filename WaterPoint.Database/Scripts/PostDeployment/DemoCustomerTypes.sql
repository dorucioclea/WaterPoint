
DECLARE @orgId INT = (SELECT Id FROM Organization WHERE Name = 'Water Point')

IF NOT EXISTS(SELECT TOP 1 * FROM dbo.CustomerType WHERE OrganizationId = @orgId)
BEGIN
    INSERT INTO dbo.CustomerType
    (OrganizationId,Description,NameDisplayStrategy)
    VALUES
    (@orgId,N'标准','/**LastName**/ /**OtherName**/ /**FirstName**/')

    INSERT INTO dbo.CustomerType
    (OrganizationId,Description,NameDisplayStrategy)
    VALUES
    (@orgId,N'特殊','/**LastName**/ /**OtherName**/ /**FirstName**/')

    INSERT INTO dbo.CustomerType
    (OrganizationId,Description,NameDisplayStrategy)
    VALUES
    (@orgId,N'个人','/**LastName**/ /**OtherName**/ /**FirstName**/')

    INSERT INTO dbo.CustomerType
    (OrganizationId,Description,NameDisplayStrategy)
    VALUES
    (@orgId,N'公司','/**LastName**/ /**OtherName**/ /**FirstName**/')
END
GO