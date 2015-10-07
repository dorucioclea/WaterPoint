CREATE TABLE [im].[Banner]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [OrganizationId] INT NOT NULL,
    [BannerTypeId] INT NOT NULL,
    [ImageId] INT NOT NULL,
    [IsActive] BIT NOT NULL DEFAULT(1),
    [Name] VARCHAR(50) NOT NULL,
    [Url] VARCHAR(260) NULL,
    [Description] VARCHAR(150) NULL,
    [UtcCreated] DATETIME2(0) NOT NULL DEFAULT(GETUTCDATE()),
    [UtcUpdated] DATETIME2(0) NOT NULL DEFAULT(GETUTCDATE())
    CONSTRAINT [FK_Banner_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization]([Id]),
    CONSTRAINT [FK_Banner_Image] FOREIGN KEY ([ImageId]) REFERENCES [dbo].[Image]([Id]),
    CONSTRAINT [FK_Banner_BannerType] FOREIGN KEY ([BannerTypeId]) REFERENCES [im].[BannerType]([Id])
)
