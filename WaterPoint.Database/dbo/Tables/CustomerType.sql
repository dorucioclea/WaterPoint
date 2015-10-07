﻿CREATE TABLE [dbo].[CustomerType]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [OrganizationId] INT NOT NULL,
    [Description] NVARCHAR(50) NOT NULL,
    [NameDisplayStrategy] VARCHAR(50) NULL,
	[UtcCreated] DATETIME2(0) NOT NULL DEFAULT(GETUTCDATE()),
	[UtcUpdated] DATETIME2(0) NOT NULL DEFAULT(GETUTCDATE())
)
