﻿CREATE TABLE [dbo].[InvoiceJobTimesheet]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [InvoiceId] INT NOT NULL,
    [JobTimesheetId] INT NOT NULL,
    [InvoiceJobTaskId] INT NULL,
    [StartDateTime] DATETIME2(0) NULL,
    [EndDateTime] DATETIME2(0) NULL,
    [RoundedMinutes] INT NOT NULL DEFAULT(0),
    [ShortDescription] NVARCHAR (100) NULL,
    [LongDescription] NVARCHAR (MAX) NULL,
    [IsBillable] BIT NOT NULL DEFAULT(0),
    [BaseRate] DECIMAL(10,3) NOT NULL DEFAULT(0),
    [BillableRate] DECIMAL(10,3) NOT NULL DEFAULT(0),
	[UtcCreated] DATETIME2(0) NOT NULL DEFAULT(GETUTCDATE()),
	[UtcUpdated] DATETIME2(0) NOT NULL DEFAULT(GETUTCDATE()),
	[Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
    CONSTRAINT [FK_InvoiceJobTimesheet_Invoice] FOREIGN KEY ([InvoiceId]) REFERENCES [dbo].[Invoice]([Id]),
    CONSTRAINT [FK_InvoiceJobTimesheet_JobTimesheet] FOREIGN KEY ([JobTimesheetId]) REFERENCES [dbo].[JobTimesheet]([Id]),
)
