﻿CREATE TABLE [dbo].[QuoteTimesheet]
(
    [Id] INT NOT NULL IDENTITY,
    [QuoteTaskId] INT NOT NULL,
    [LastChangeOrganizationUserId] INT NULL,
    [IsWriteOff] BIT NOT NULL DEFAULT(0),
    [StaffId] INT NOT NULL,
    [StartDateTime] DATETIME2(0) NULL,
    [EndDateTime] DATETIME2(0) NULL,
    [OriginalMinutes] INT NULL,
    [RoundedMinutes] INT NULL,
    [ShortDescription] NVARCHAR (100) NULL,
    [LongDescription] NVARCHAR (2000) NULL,
    [IsBillable] BIT NOT NULL DEFAULT(0),
    [BaseRate] DECIMAL(10,3) NOT NULL DEFAULT(0),
    [BillableRate] DECIMAL(10,3) NOT NULL DEFAULT(0),
    [IsDuration] BIT NOT NULL,
    [IsDeleted] BIT NOT NULL DEFAULT(0),
    [Version] ROWVERSION NOT NULL,
	[UtcCreated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
	[UtcUpdated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
	[Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
    CONSTRAINT [PK_dbo_QuoteTimesheet_Id] PRIMARY KEY CLUSTERED (Id ASC),
    CONSTRAINT [FK_dbo_QuoteTimesheet_dbo_QuoteTask] FOREIGN KEY ([QuoteTaskId]) REFERENCES [dbo].[QuoteTask]([Id]),
    CONSTRAINT [FK_dbo_QuoteTimesheet_dbo_Staff] FOREIGN KEY ([StaffId]) REFERENCES [dbo].[Staff]([Id]),
    CONSTRAINT [FK_dbo_QuoteTimesheet_dbo_OrganizationUser] FOREIGN KEY ([LastChangeOrganizationUserId]) REFERENCES [dbo].[OrganizationUser]([Id])
)