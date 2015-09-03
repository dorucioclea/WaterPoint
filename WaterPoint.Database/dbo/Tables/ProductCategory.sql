CREATE TABLE [dbo].[ProductCategory]
(
    [ProductId] INT NOT NULL, 
    [CategoryId] INT NOT NULL,
    CONSTRAINT [FK_ProductCategory_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product]([Id]),
    CONSTRAINT [FK_ProductCaetgory_Category] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category]([Id]), 
    CONSTRAINT [PK_ProductCategory] PRIMARY KEY ([ProductId], [CategoryId])
)
