CREATE TABLE [dbo].[JobCategory]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [OrganizationId] INT NOT NULL,
    [Description] NVARCHAR(100) NULL,
    [IsInternal] BIT NOT NULL DEFAULT(0),
    [IsCapacityReducing] BIT NOT NULL DEFAULT(0)
)
