﻿CREATE TABLE [dbo].[JobCategory]
(
    [Id] INT NOT NULL IDENTITY,
    [OrganizationId] INT NOT NULL,
    [Description] NVARCHAR(100) NULL,
    [IsInternal] BIT NOT NULL DEFAULT(0),
    [IsCapacityReducing] BIT NOT NULL DEFAULT(0),
	[IsDeleted] BIT NOT NULL DEFAULT(0),
    [Version] ROWVERSION NOT NULL,
	[UtcCreated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
	[UtcUpdated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
    CONSTRAINT [PK_dbo_JobCategory_Id] PRIMARY KEY CLUSTERED (Id ASC),
)
