CREATE TABLE [dbo].[TaskDefinition]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [OrganizationId] INT NOT NULL,
    [Name] NVARCHAR(200) NOT NULL,
    [Description] NVARCHAR(MAX) NOT NULL,
    [BaseRate] DECIMAL(10,3) NOT NULL DEFAULT(0),
    [BillableRate] DECIMAL(10,3) NOT NULL DEFAULT(0),
    [IsDeleted] BIT NOT NULL DEFAULT(0),
    [Version] ROWVERSION NOT NULL,
	[UtcCreated] DATETIME2(0) NOT NULL DEFAULT(GETUTCDATE()),
	[UtcUpdated] DATETIME2(0) NOT NULL DEFAULT(GETUTCDATE()),
    [Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
    CONSTRAINT [FK_TaskDefinition_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization]([Id])
)
