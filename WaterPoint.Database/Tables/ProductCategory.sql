CREATE TABLE [dbo].[ProductCategory]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	[ProductId] int not null,
	[CategoryId] int not null,
	CONSTRAINT [FK_ProductCategory_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id]),
	CONSTRAINT [FK_ProductCategory_Category] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([Id])
)
