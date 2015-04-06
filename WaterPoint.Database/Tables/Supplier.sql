CREATE TABLE [dbo].[Supplier]
(
	[Id] INT NOT NULL IDENTITY, 
	[OrganizationId] INT NOT NULL,
    [Name] NVARCHAR(150) NOT NULL, 
    [DisplayName] NVARCHAR(150) NULL, 
    [Mobile] NVARCHAR(100) NULL, 
    [Phone1] NVARCHAR(100) NULL, 
    [Uid] UNIQUEIDENTIFIER DEFAULT(NEWID()) NOT NULL, 
    CONSTRAINT [PK_Supplier] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_Supplier_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization] ([Id])	
)
