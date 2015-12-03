CREATE TABLE [dbo].[ModuleComponent]
(
    [ModuleId] INT NOT NULL ,
    [ComponentId] INT NOT NULL,
    PRIMARY KEY ([ModuleId], [ComponentId]),
    CONSTRAINT [FK_ModuleComponent_Module] FOREIGN KEY ([ModuleId]) REFERENCES [dbo].[Module]([Id]),
    CONSTRAINT [FK_ModuleComponent_Component] FOREIGN KEY ([ComponentId]) REFERENCES [dbo].[Component]([Id]),
)
