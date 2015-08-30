CREATE TABLE [dbo].[Sku]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [ProductId] INT NOT NULL,
	[Code] VARCHAR(30) NOT NULL,
    [Quantity] INT NOT NULL DEFAULT 0, 
    [CreatedOn] DATETIME2(0) NOT NULL DEFAULT getutcdate(), 
    [UpdatedOn] DATETIME2(0) NOT NULL DEFAULT getutcdate(), 
    

)
