CREATE TABLE [dbo].[CustomerShop]
(
    [ShopId] INT NOT NULL,
    [CustomerId] INT NOT NULL,
    CONSTRAINT [FK_CustomerShop_Shop] FOREIGN KEY ([ShopId]) REFERENCES [dbo].[Shop]([Id]),
    CONSTRAINT [FK_CustomerShop_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer]([Id]), 
    CONSTRAINT [PK_CustomerShop] PRIMARY KEY ([ShopId], [CustomerId])
)
