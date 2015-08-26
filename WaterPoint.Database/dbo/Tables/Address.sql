CREATE TABLE [dbo].[Address]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Street] NVARCHAR(150) NOT NULL, 
    [StreetExtraLine] NVARCHAR(150) NULL, 
    [Suburb] NVARCHAR(50) NOT NULL, 
    [City] NVARCHAR(50) NOT NULL, 
    [PostCode] VARCHAR(20) NULL, 
    [CountryId] INT NOT NULL,
	CONSTRAINT [FK_Address_Country] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[Country] ([Id])
)
