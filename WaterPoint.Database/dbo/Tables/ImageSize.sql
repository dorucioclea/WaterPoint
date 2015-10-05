CREATE TABLE [dbo].[ImageSize]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [OrganizationId] INT NOT NULL,
    [ImageSizeTypeId] INT NOT NULL,
    [Name] VARCHAR(50) NOT NULL,
    [Length] INT NOT NULL,
    [Width] INT NOT NULL,
    [UtcCreated] DATETIME2(0) NOT NULL DEFAULT(GETUTCDATE()),
    [UtcUpdated] DATETIME2(0) NOT NULL DEFAULT(GETUTCDATE()),
    CONSTRAINT [FK_ImageSize_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization]([Id]),
    CONSTRAINT [FK_ImageSize_ImageSizeType] FOREIGN KEY ([ImageSizeTypeId]) REFERENCES [dbo].[ImageSizeType]([Id])
)
