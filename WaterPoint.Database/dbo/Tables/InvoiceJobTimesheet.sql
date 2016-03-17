﻿CREATE TABLE [dbo].[InvoiceJobTimesheet]
(
    [Id] INT NOT NULL IDENTITY,
    [InvoiceId] INT NOT NULL,
    [LastChangeOrganizationUserId] INT NULL,
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
    [Version] ROWVERSION NOT NULL,
	[UtcCreated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
	[UtcUpdated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
	[Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
    CONSTRAINT [PK_dbo_InvoiceJobTimesheet_Id] PRIMARY KEY CLUSTERED (Id ASC),
    CONSTRAINT [FK_dbo_InvoiceJobTimesheet_dbo_Invoice] FOREIGN KEY ([InvoiceId]) REFERENCES [dbo].[Invoice]([Id]),
    CONSTRAINT [FK_dbo_InvoiceJobTimesheet_dbo_JobTimesheet] FOREIGN KEY ([JobTimesheetId]) REFERENCES [dbo].[JobTimesheet]([Id]),
    CONSTRAINT [FK_dbo_InvoiceJobTimesheet_dbo_OrganizationUser] FOREIGN KEY ([LastChangeOrganizationUserId]) REFERENCES [dbo].[OrganizationUser]([Id])
)
