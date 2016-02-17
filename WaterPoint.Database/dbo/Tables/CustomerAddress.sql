CREATE TABLE [dbo].[CustomerAddress]
(
    [CustomerId] INT NOT NULL ,
    [AddressId] INT NOT NULL,
    [IsPrimary] BIT NOT NULL DEFAULT 0,
    [IsPostAddress] BIT NOT NULL DEFAULT 0,
    PRIMARY KEY ([AddressId], [CustomerId]),
    CONSTRAINT [FK_CustomerAddress_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer]([Id]),
    CONSTRAINT [FK_CustomerAddress_Address] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Address]([Id])
)
