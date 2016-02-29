CREATE TABLE [dbo].[Address]
(
	[Id] INT NOT NULL IDENTITY,
    [OrganizationId] INT NOT NULL,
    [Street] NVARCHAR(150) NULL,
    [StreetExtraLine] NVARCHAR(150) NULL,
    [Suburb] NVARCHAR(50) NULL,
    [City] NVARCHAR(50) NULL,
    [Province] NVARCHAR(50) NULL,
    [PostCode] VARCHAR(20) NULL,
    [CountryId] INT NOT NULL,
    [IsDeleted] BIT NOT NULL DEFAULT(0),
    [Version] ROWVERSION NOT NULL,
    CONSTRAINT [PK_dbo_Address_Id] PRIMARY KEY CLUSTERED (Id ASC),
	CONSTRAINT [FK_dbo_Address_dbo_Country] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[Country] ([Id]),
    CONSTRAINT [FK_dbo_Address_dbo_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization] ([Id])
)
