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

IF(NOT EXISTS(SELECT TOP 1 * FROM dbo.Staff))
    BEGIN
        DBCC checkident ('dbo.Staff', reseed, 10000)
    END
GO
