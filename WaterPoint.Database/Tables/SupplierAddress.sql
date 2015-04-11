CREATE TABLE [dbo].[SupplierAddress]
(
	[Id] INT NOT NULL IDENTITY,
	[AddressId] INT NOT NULL,
	[SupplierId] INT NOT NULL
	CONSTRAINT [PK_SupplierAddress] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_SupplierAddress_Address] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Address] ([Id]),
	CONSTRAINT [FK_SupplierAddress_Supplier] FOREIGN KEY ([SupplierId]) REFERENCES [dbo].[Supplier] ([Id])	
)
