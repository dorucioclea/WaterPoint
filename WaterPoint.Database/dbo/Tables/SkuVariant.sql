CREATE TABLE [dbo].[SkuVariant]
(
    [SkuId] INT NOT NULL, 
    [VariantId] INT NOT NULL,
    CONSTRAINT [FK_SkuVariant_Sku] FOREIGN KEY ([SkuId]) REFERENCES [dbo].[Sku]([Id]),
    CONSTRAINT [FK_SkuVariant_Variant] FOREIGN KEY ([VariantId]) REFERENCES [dbo].[Variant]([Id]), 
    CONSTRAINT [PK_SkuVariant] PRIMARY KEY ([SkuId], [VariantId])
)
