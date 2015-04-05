CREATE TABLE [dbo].[Supplier]
(
	[Id] INT NOT NULL IDENTITY, 
    [Name] VARCHAR(50) NOT NULL, 
    [DisplayName] VARCHAR(50) NULL, 
    [Mobile] VARCHAR(50) NULL, 
    [Phone1] VARCHAR(50) NULL, 
    [Uid] UNIQUEIDENTIFIER DEFAULT(NEWID()), 
    CONSTRAINT [PK_Supplier] PRIMARY KEY ([Id]) 
)
