CREATE TABLE [dbo].[ModuleComponent]
(
    [ModuleId] INT NOT NULL ,
    [ComponentId] INT NOT NULL,
    [Version] ROWVERSION NOT NULL,
	[UtcCreated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
	[UtcUpdated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
    PRIMARY KEY ([ModuleId], [ComponentId]),
    CONSTRAINT [FK_ModuleComponent_Module] FOREIGN KEY ([ModuleId]) REFERENCES [dbo].[Module]([Id]),
    CONSTRAINT [FK_ModuleComponent_Component] FOREIGN KEY ([ComponentId]) REFERENCES [dbo].[Component]([Id]),
)
