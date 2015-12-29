CREATE TABLE [dbo].[Module]
(
    [Id] INT NOT NULL,
    [Code] VARCHAR(50) NOT NULL,
    [Name] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(200) NULL,
	[UtcCreated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
	[UtcUpdated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
    CONSTRAINT [PK_dbo_Module_Id] PRIMARY KEY CLUSTERED (Id ASC),
    --CONSTRAINT [FK_Privilege_PrivilegeCategory] FOREIGN KEY ([PrivilegeCategoryId]) REFERENCES [dbo].[PrivilegeCategory]([Id]),
)
