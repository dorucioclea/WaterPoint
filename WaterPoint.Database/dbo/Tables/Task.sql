﻿CREATE TABLE [dbo].[Task]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [OrganizationId] INT NOT NULL,
    [Name] NVARCHAR(200) NOT NULL,
    [Description] NVARCHAR(MAX) NOT NULL,
    [BaseRate] DECIMAL(10,3) NOT NULL DEFAULT(0),
    [BillableRate] DECIMAL(10,3) NOT NULL DEFAULT(0),
    [IsDeleted] BIT NOT NULL DEFAULT(0),
    [Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
    CONSTRAINT [FK_Task_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization]([Id])
)
