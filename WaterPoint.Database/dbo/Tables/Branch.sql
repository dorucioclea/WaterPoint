CREATE TABLE [dbo].[Branch]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [OrganizationId] INT NOT NULL,
    [Name] VARCHAR(50) NULL,
    [IsActive] BIT NOT NULL DEFAULT(0),
    [IsMainBranch] BIT NOT NULL DEFAULT(0),
    [UtcCreated] DATETIME2(0) NOT NULL DEFAULT(GETUTCDATE()),
    [UtcUpdated] DATETIME2(0) NOT NULL DEFAULT(GETUTCDATE()),
    CONSTRAINT [FK_Branch_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization]([Id]),
)
