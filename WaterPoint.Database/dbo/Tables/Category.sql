﻿CREATE TABLE [dbo].[Category]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
    [Description] VARCHAR(200) NULL,
    [ShopId] INT NOT NULL,
    [LongDescription] VARCHAR(MAX) NULL,
    [IsDeleted] BIT NOT NULL DEFAULT(0),
    [IsActive] BIT NOT NULL DEFAULT(0),
    [Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
    [UtcCreatedOn] DATETIME2(0) NOT NULL DEFAULT GETUTCDATE(), 
    [UtcUpdatedOn] DATETIME2(0) NOT NULL DEFAULT GETUTCDATE(),
    CONSTRAINT [FK_Category_Shop] FOREIGN KEY ([ShopId]) REFERENCES [dbo].[Shop]([Id]),
)
