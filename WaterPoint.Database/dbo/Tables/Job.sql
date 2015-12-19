CREATE TABLE [dbo].[Job]
(
	[Id] INT NOT NULL IDENTITY,
    [OrganizationId] INT NOT NULL,
    [JobStatusId] INT NOT NULL,
    [JobCategoryId] INT NULL,
    [Code] VARCHAR(50) NOT NULL,
	[ShortDescription] NVARCHAR(200) NULL,
    [LongDescription] NVARCHAR(MAX) NULL,
    [CustomerId] INT NOT NULL,
    [StartDate] DATE NOT NULL,
    [EndDate] DATE NOT NULL,
    [DueDate] DATE NULL,
    [ExcludeFromWip] BIT NOT NULL DEFAULT(0),
    [Version] ROWVERSION NOT NULL,
	[UtcCreated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
	[UtcUpdated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
	[Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
    CONSTRAINT [PK_dbo_Job_Id] PRIMARY KEY CLUSTERED (Id ASC),
    CONSTRAINT [FK_Job_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer]([Id]),
    CONSTRAINT [FK_Job_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization]([Id]),
    CONSTRAINT [FK_Job_JobStatus] FOREIGN KEY ([JobStatusId]) REFERENCES [dbo].[JobStatus] ([Id]),
    CONSTRAINT [FK_Job_Category] FOREIGN KEY ([JobCategoryId]) REFERENCES [dbo].[JobCategory]([Id])
);
GO

CREATE FULLTEXT INDEX ON [dbo].[Job]
(
	Code LANGUAGE 1033,
    ShortDescription LANGUAGE 2052
)
KEY INDEX [PK_dbo_Job_Id]
ON [SiteSearch]
WITH STOPLIST OFF;
GO
