CREATE TABLE [dbo].[ProductFlag]
(   
    [ProductId] INT NOT NULL,
    [FlagId] INT NOT NULL, 
    CONSTRAINT [FK_ProductFlag_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product]([Id]),
    CONSTRAINT [FK_ProductFlag_Flag] FOREIGN KEY ([FlagId]) REFERENCES [dbo].[Flag]([Id]), 
    CONSTRAINT [PK_ProductFlag] PRIMARY KEY ([ProductId], [FlagId])
)
