CREATE TABLE [im].[VariantType]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [OrganizationId] INT NOT NULL,
    [Name] VARCHAR(10) NOT NULL,
    CONSTRAINT [FK_VariantType_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization]([Id]),
)
