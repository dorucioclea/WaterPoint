IF NOT EXISTS(SELECT TOP 1 * FROM dbo.JobCategory)
    BEGIN
        DECLARE @orgId INT = (SELECT Id FROM  dbo.Organization WHERE Name = 'Water Point')

        INSERT INTO dbo.JobCategory
        ([OrganizationId], [Description], [IsInternal], [IsCapacityReducing])
        VALUES
        (@orgId, N'病假', 1, 1)

        INSERT INTO dbo.JobCategory
        ([OrganizationId], [Description], [IsInternal], [IsCapacityReducing])
        VALUES
        (@orgId, N'年假', 1, 1)

        INSERT INTO dbo.JobCategory
        ([OrganizationId], [Description], [IsInternal], [IsCapacityReducing])
        VALUES
        (@orgId, N'前端设计', 0, 0)

        INSERT INTO dbo.JobCategory
        ([OrganizationId], [Description], [IsInternal], [IsCapacityReducing])
        VALUES
        (@orgId, N'后端设计', 0, 0)
    END
GO
