CREATE TABLE [dbo].[Branch]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL,
	[RestaurantId] INT NOT NULL, 
    [AddressId] INT NOT NULL, 
    [CreatedOn] DATETIME2(0) NOT NULL DEFAULT GETUTCDATE(), 
    [UpdatedOn] DATETIME2(0) NOT NULL DEFAULT GETUTCDATE(),
	CONSTRAINT [FK_Branch_Restaurant] FOREIGN KEY ([RestaurantId]) REFERENCES [dbo].[Restaurant] ([Id])
)
