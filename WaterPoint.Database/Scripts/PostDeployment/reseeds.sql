IF(NOT EXISTS(SELECT TOP 1 * FROM dbo.Customer))
    BEGIN
        DBCC checkident ('dbo.Customer', reseed, 10000)
    END

IF(NOT EXISTS(SELECT TOP 1 * FROM dbo.Organization))
    BEGIN
        DBCC checkident ('dbo.Organization', reseed, 1000)
    END

IF(NOT EXISTS(SELECT TOP 1 * FROM dbo.JobStatus))
    BEGIN
        DBCC checkident ('dbo.JobStatus', reseed, 100)
    END
GO

IF(NOT EXISTS(SELECT TOP 1 * FROM dbo.Job))
    BEGIN
        DBCC checkident ('dbo.Job', reseed, 10000)
    END
GO

IF(NOT EXISTS(SELECT TOP 1 * FROM dbo.OrganizationUser))
    BEGIN
        DBCC checkident ('dbo.OrganizationUser', reseed, 10000)
    END
GO

IF(NOT EXISTS(SELECT TOP 1 * FROM dbo.Staff))
    BEGIN
        DBCC checkident ('dbo.Staff', reseed, 10000)
    END
GO

IF(NOT EXISTS(SELECT TOP 1 * FROM dbo.TaskDefinition))
    BEGIN
        DBCC checkident ('dbo.TaskDefinition', reseed, 10000)
    END
GO



IF(NOT EXISTS(SELECT TOP 1 * FROM dbo.JobTask))
    BEGIN
        DBCC checkident ('dbo.JobTask', reseed, 1000)
    END
GO

IF(NOT EXISTS(SELECT TOP 1 * FROM dbo.JobCostItem))
    BEGIN
        DBCC checkident ('dbo.JobCostItem', reseed, 1000)
    END
GO




