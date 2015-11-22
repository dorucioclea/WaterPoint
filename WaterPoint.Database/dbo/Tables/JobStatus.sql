CREATE TABLE [dbo].[JobStatus]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(50) NOT NULL,
    [OrganizationId] INT NOT NULL,
    [IsDeleted] BIT NOT NULL DEFAULT(0),
    [IsOnHold] BIT NOT NULL DEFAULT(0),
    [IsCompleted] BIT NOT NULL DEFAULT(0),
    [IsActive] BIT NOT NULL DEFAULT(1),
    [IsCancelled] BIT NOT NULL DEFAULT(0),
    [DisplayOrder] INT NOT NULL,
    CONSTRAINT [FK_JobStatus_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization]([Id]),
)
