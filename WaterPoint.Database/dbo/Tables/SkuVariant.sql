CREATE TABLE [dbo].[SkuVariant]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [SkuId] INT NOT NULL, 
    [VariantTypeId] INT NOT NULL, 
    [TextValue] VARCHAR(10) NULL, 
    [NumberValue] DECIMAL(10, 3) NULL
)
