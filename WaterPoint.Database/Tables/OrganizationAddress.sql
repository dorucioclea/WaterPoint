CREATE TABLE [dbo].[OrganizationAddress]
(
	[Id] INT NOT NULL IDENTITY,
	[OrganizationId] INT NOT NULL,
	[AddressId] INT NOT NULL,	
	[IsPrimary] BIT NOT NULL DEFAULT 0, 
    [IsPostAddress] BIT NOT NULL DEFAULT 0, 
	[IsBillingAddress] BIT NOT NULL DEFAULT 0, 
	[IsDeliveryAddress] BIT NOT NULL DEFAULT 0,
	CONSTRAINT [PK_OrganizationAddress] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_OrganizationAddress_Address] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Address] ([Id]),	
)
