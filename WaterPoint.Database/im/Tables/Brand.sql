CREATE TABLE [im].[Brand]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [OrganizationId] INT NOT NULL,
    [Name] VARCHAR(50) NOT NULL,
    [Description] VARCHAR(150) NULL,
    [IsActive] BIT NOT NULL DEFAULT(1),
    [UtcCreated] DATETIME2(0) NOT NULL DEFAULT GETUTCDATE(),
    [UtcUpdated] DATETIME2(0) NOT NULL DEFAULT GETUTCDATE(),
    [Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
    CONSTRAINT [FK_Brand_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization]([Id]),
)
