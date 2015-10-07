CREATE TABLE [im].[ProductCategory]
(
    [ProductId] INT NOT NULL,
    [CategoryId] INT NOT NULL,
    CONSTRAINT [FK_ProductCategory_Product] FOREIGN KEY ([ProductId]) REFERENCES [im].[Product]([Id]),
    CONSTRAINT [FK_ProductCaetgory_Category] FOREIGN KEY ([CategoryId]) REFERENCES [im].[Category]([Id]),
    CONSTRAINT [PK_ProductCategory] PRIMARY KEY ([ProductId], [CategoryId])
)
