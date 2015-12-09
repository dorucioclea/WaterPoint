CREATE TABLE [dbo].[JobStatus]
(
    [Id] INT NOT NULL IDENTITY,
    [Name] NVARCHAR(50) NOT NULL,
    [OrganizationId] INT NOT NULL,
    [ForPlanned] BIT NOT NULL DEFAULT(0),
    [ForDeleted] BIT NOT NULL DEFAULT(0),
    [ForOnHold] BIT NOT NULL DEFAULT(0),
    [ForCompleted] BIT NOT NULL DEFAULT(0),
    [ForInProgress] BIT NOT NULL DEFAULT(0),
    [ForCancelled] BIT NOT NULL DEFAULT(0),
    [IsDeleted] BIT NOT NULL DEFAULT(0),
    [DisplayOrder] INT NOT NULL,
    [Version] ROWVERSION NOT NULL,
	[UtcCreated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
	[UtcUpdated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
    CONSTRAINT [PK_dbo_JobStatus_Id] PRIMARY KEY CLUSTERED (Id ASC),
    CONSTRAINT [FK_JobStatus_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization]([Id]),
)
