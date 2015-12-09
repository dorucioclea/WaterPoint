CREATE TABLE [dbo].[Privilege]
(
    [Id] INT NOT NULL IDENTITY,
    [PrivilegeCategoryId] INT NOT NULL,
    [Code] VARCHAR(50) NOT NULL,
    [Name] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(MAX) NOT NULL,
    [Version] ROWVERSION NOT NULL,
	[UtcCreated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
	[UtcUpdated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
    CONSTRAINT [PK_dbo_Privilege_Id] PRIMARY KEY CLUSTERED (Id ASC),
    CONSTRAINT [FK_Privilege_PrivilegeCategory] FOREIGN KEY ([PrivilegeCategoryId]) REFERENCES [dbo].[PrivilegeCategory]([Id]),
)
