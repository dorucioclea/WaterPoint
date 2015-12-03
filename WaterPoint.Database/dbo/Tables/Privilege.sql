CREATE TABLE [dbo].[Privilege]
(
    [Id] INT NOT NULL PRIMARY KEY,
    [PrivilegeCategoryId] INT NOT NULL,
    [Code] VARCHAR(50) NOT NULL,
    [Name] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(MAX) NOT NULL,
    CONSTRAINT [FK_Privilege_PrivilegeCategory] FOREIGN KEY ([PrivilegeCategoryId]) REFERENCES [dbo].[PrivilegeCategory]([Id]),
)
