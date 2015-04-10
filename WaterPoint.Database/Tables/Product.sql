CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY Identity,
	[SupplierId] int not null,
	[Name] nvarchar(200) not null,
	CONSTRAINT [FK_Product_Supplier] FOREIGN KEY ([SupplierId]) REFERENCES [dbo].[Supplier] ([Id])
)
