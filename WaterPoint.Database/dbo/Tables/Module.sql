CREATE TABLE [dbo].[Module]
(
    [Id] INT NOT NULL PRIMARY KEY,
    [Code] VARCHAR(50) NOT NULL,
    [Name] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(MAX) NOT NULL,
    --CONSTRAINT [FK_Privilege_PrivilegeCategory] FOREIGN KEY ([PrivilegeCategoryId]) REFERENCES [dbo].[PrivilegeCategory]([Id]),
)
