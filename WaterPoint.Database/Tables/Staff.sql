CREATE TABLE [dbo].[Staff]
(
	[Id] INT NOT NULL IDENTITY, 
	[OrganizationId] INT NOT NULL,
    [Name] NVARCHAR(150) NOT NULL,
    [Email] NVARCHAR(100) NULL, 
	[Mobile] NVARCHAR(100) NULL, 
    [Phone] NVARCHAR(100) NULL, 
    [Uid] UNIQUEIDENTIFIER DEFAULT(NEWID()) NOT NULL, 
    CONSTRAINT [PK_Staff] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_Staff_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization] ([Id])
)
