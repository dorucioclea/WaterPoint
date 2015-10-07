CREATE TABLE [im].[Sku]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [ProductId] INT NOT NULL,
    [BranchId] INT NOT NULL,
	[Code] VARCHAR(30) NOT NULL,
    [Quantity] INT NOT NULL DEFAULT 0,
    [UtcCreated] DATETIME2(0) NOT NULL DEFAULT GETUTCDATE(),
    [UtcUpdated] DATETIME2(0) NOT NULL DEFAULT GETUTCDATE()
    CONSTRAINT [FK_Sku_Product] FOREIGN KEY ([ProductId]) REFERENCES [im].[Product]([Id]),
    CONSTRAINT [FK_Sku_Branch] FOREIGN KEY ([BranchId]) REFERENCES [dbo].[Branch]([Id]),
)
