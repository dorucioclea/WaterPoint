CREATE TABLE [im].[Variant]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [OrganizationId] INT NOT NULL,
    [VariantTypeId] INT NOT NULL,
	[Value] VARCHAR(10) NOT NULL,
    [DisplayName] VARCHAR(30) NULL,
    [Order] INT NULL,
    CONSTRAINT [FK_Variant_VariantType] FOREIGN KEY (VariantTypeId) REFERENCES [im].[VariantType] (Id),
    CONSTRAINT [FK_Variant_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization]([Id]),
)
