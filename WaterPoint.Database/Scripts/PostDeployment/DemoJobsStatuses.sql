IF NOT EXISTS(SELECT TOP 1 * FROM dbo.JobStatus)
    BEGIN
        DECLARE @orgId INT = (SELECT Id FROM  dbo.Organization WHERE Name = 'Water Point')

        INSERT INTO [dbo].[JobStatus]
        ([Name],[OrganizationId],[ForPlanned],[DisplayOrder])
        VALUES
        (N'计划', @orgId, 1, 1)

        INSERT INTO [dbo].[JobStatus]
        ([Name],[OrganizationId],[ForInProgress],[DisplayOrder])
        VALUES
        (N'进展中', @orgId, 1, 1)

        INSERT INTO [dbo].[JobStatus]
        ([Name],[OrganizationId],[ForDeleted],[DisplayOrder])
        VALUES
        (N'已删除', @orgId, 1, 1)

        INSERT INTO [dbo].[JobStatus]
        ([Name],[OrganizationId],[ForOnHold],[DisplayOrder])
        VALUES
        (N'暂停中', @orgId, 1, 1)

        INSERT INTO [dbo].[JobStatus]
        ([Name],[OrganizationId],[ForCompleted],[DisplayOrder])
        VALUES
        (N'已完成', @orgId, 1, 1)

        INSERT INTO [dbo].[JobStatus]
        ([Name],[OrganizationId],[ForCancelled],[DisplayOrder])
        VALUES
        (N'已取消', @orgId, 1, 1)
    END
GO
