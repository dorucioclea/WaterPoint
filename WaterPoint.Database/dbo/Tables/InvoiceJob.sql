﻿CREATE TABLE [dbo].[InvoiceJob]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [InvoiceId] INT NOT NULL,
    [JobId] INT NOT NULL,
    [Description] NVARCHAR(MAX),
	[UtcCreated] DATETIME2(0) NOT NULL DEFAULT(GETUTCDATE()),
	[UtcUpdated] DATETIME2(0) NOT NULL DEFAULT(GETUTCDATE()),
	[Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
    CONSTRAINT [FK_InvoiceJob_Job] FOREIGN KEY ([JobId]) REFERENCES [dbo].[Job]([Id]),
    CONSTRAINT [FK_InvoiceJob_Invoice] FOREIGN KEY ([InvoiceId]) REFERENCES [dbo].[Invoice]([Id]),

)
