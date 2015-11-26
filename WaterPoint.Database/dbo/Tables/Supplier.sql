﻿CREATE TABLE [dbo].[Supplier]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [UtcCreated] DATETIME2(0) NOT NULL DEFAULT(GETUTCDATE()),
	[UtcUpdated] DATETIME2(0) NOT NULL DEFAULT(GETUTCDATE()),
    [Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
)
