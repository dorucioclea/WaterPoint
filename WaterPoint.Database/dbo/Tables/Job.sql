CREATE TABLE [dbo].[Job]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [OrganizationId] INT NOT NULL,
    [JobStatusId] INT NOT NULL,
    [JobCategoryId] INT NOT NULL,
    [Code] VARCHAR(50) NOT NULL,
	[ShortDescription] NVARCHAR(200) NULL,
    [LongDescription] NVARCHAR(MAX) NULL,
    [CustomerId] INT NOT NULL,
    [StartDate] DATE NOT NULL,
    [EndDate] DATE NOT NULL,
    [DueDate] DATE NULL,
    [UpdatedByStaffId] INT NULL,
    [ExcludeFromWip] BIT NOT NULL DEFAULT(0),
    [Version] ROWVERSION NOT NULL,
	[UtcCreated] DATETIME2(0) NOT NULL DEFAULT(GETUTCDATE()),
	[UtcUpdated] DATETIME2(0) NOT NULL DEFAULT(GETUTCDATE()),
	[Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
    CONSTRAINT [FK_Job_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer]([Id]),
    CONSTRAINT [FK_Job_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization]([Id]),
    CONSTRAINT [FK_Job_JobStatus] FOREIGN KEY ([JobStatusId]) REFERENCES [dbo].[JobStatus] ([Id]),
    CONSTRAINT [FK_Job_Category] FOREIGN KEY ([JobCategoryId]) REFERENCES [dbo].[JobCategory]([Id])
)
