CREATE TABLE [dbo].[Address]
(
	[Id] INT NOT NULL IDENTITY,
    [Street] NVARCHAR(150) NOT NULL,
    [StreetExtraLine] NVARCHAR(150) NULL,
    [Suburb] NVARCHAR(50) NOT NULL,
    [City] NVARCHAR(50) NOT NULL,
    [PostCode] VARCHAR(20) NULL,
    [CountryId] INT NOT NULL,
    [Version] ROWVERSION NOT NULL,
    CONSTRAINT [PK_dbo_Address_Id] PRIMARY KEY CLUSTERED (Id ASC),
	CONSTRAINT [FK_Address_Country] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[Country] ([Id])
)
