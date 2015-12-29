CREATE TABLE [dbo].[Privilege]
(
    [Id] INT NOT NULL,
    [Code] VARCHAR(50) NOT NULL,
    [Name] NVARCHAR(100) NOT NULL,
    [IsDeleted] BIT NOT NULL DEFAULT(0),
    [Description] NVARCHAR(200) NULL,
    CONSTRAINT [PK_dbo_Privilege_Id] PRIMARY KEY CLUSTERED (Id ASC)
)
