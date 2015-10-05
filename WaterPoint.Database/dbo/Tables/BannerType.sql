CREATE TABLE [dbo].[BannerType]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [OrganizationId] INT NOT NULL,
    [Name] VARCHAR(100) NULL,    
    CONSTRAINT [FK_BrandType_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization]([Id]),
)
