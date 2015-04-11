CREATE TABLE [dbo].[SupplierAddress]
(
	[Id] INT NOT NULL IDENTITY,
	[SupplierId] INT NOT NULL,
	[AddressId] INT NOT NULL,	
	[IsPrimary] BIT NOT NULL DEFAULT 0, 
    [IsPostAddress] BIT NOT NULL DEFAULT 0, 
	CONSTRAINT [PK_SupplierAddress] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_SupplierAddress_Address] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Address] ([Id]),
	CONSTRAINT [FK_SupplierAddress_Supplier] FOREIGN KEY ([SupplierId]) REFERENCES [dbo].[Supplier] ([Id])	
)
