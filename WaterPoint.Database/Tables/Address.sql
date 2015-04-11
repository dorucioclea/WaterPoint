CREATE TABLE [dbo].[Address]
(
	[Id] INT NOT NULL IDENTITY,
    [StreetLine1] NVARCHAR(150) NOT NULL, 
    [StreetLine2] NVARCHAR(150) NULL, 
	[District] NVARCHAR(150) NULL, 
    [City] NVARCHAR(100) NULL, 
    [Province] NVARCHAR(100) NULL,     
    CONSTRAINT [PK_Address] PRIMARY KEY ([Id])	
)
