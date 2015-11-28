DECLARE @orgId INT = (SELECT Id FROM dbo.Organization WHERE Name = 'Water Point')
DECLARE @counter INT = 0

IF (NOT EXISTS (SELECT TOP 1 * FROM dbo.Job)) BEGIN
    WHILE @counter < 23 BEGIN
        INSERT INTO dbo.Job
		(OrganizationId, JobStatusId, JobCategoryId, Code,ShortDescription, LongDescription, CustomerId, StartDate, EndDate, UpdatedByStaffId)
		VALUES
		(@orgId, 101,(SELECT TOP 1 Id FROM dbo.[JobCategory] WHERE IsInternal = 0 AND IsCapacityReducing = 0),
		'GZ10000', N'改革开放后，中国的50个经典瞬间', N'热点：10岁华裔女孩要修改美国宪法，因为她要做美国总统[组图] sdfsf',		
		(SELECT TOP 1 Id FROM dbo.Customer)
		, GETDATE(), DATEADD(DAY, 30, GETDATE()), 5)

        SET @counter = @counter + 1
    END
END
GO