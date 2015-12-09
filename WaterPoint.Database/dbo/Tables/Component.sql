CREATE TABLE [dbo].[Component]
(
    [Id] INT NOT NULL,
    [Code] VARCHAR(50) NOT NULL,
    [Name] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(MAX) NOT NULL,
    CONSTRAINT [PK_dbo_Component_Id] PRIMARY KEY CLUSTERED (Id ASC)
)
