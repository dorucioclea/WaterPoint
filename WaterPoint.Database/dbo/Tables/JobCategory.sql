CREATE TABLE [dbo].[JobCategory]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [Description] NVARCHAR NULL,
    [IsInternal] BIT NOT NULL DEFAULT(0),
    [IsCapacityReducing] BIT NOT NULL DEFAULT(0)
)
