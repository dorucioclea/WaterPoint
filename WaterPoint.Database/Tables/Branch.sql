CREATE TABLE [dbo].[Branch]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(100) NOT NULL,
	[RestaurantId] INT NOT NULL, 
    [AddressId] INT NOT NULL
)
