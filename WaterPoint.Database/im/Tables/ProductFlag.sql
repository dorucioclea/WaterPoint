CREATE TABLE [im].[ProductFlag]
(
    [ProductId] INT NOT NULL,
    [FlagId] INT NOT NULL,
    CONSTRAINT [FK_ProductFlag_Product] FOREIGN KEY ([ProductId]) REFERENCES [im].[Product]([Id]),
    CONSTRAINT [FK_ProductFlag_Flag] FOREIGN KEY ([FlagId]) REFERENCES [im].[Flag]([Id]),
    CONSTRAINT [PK_ProductFlag] PRIMARY KEY ([ProductId], [FlagId])
)
