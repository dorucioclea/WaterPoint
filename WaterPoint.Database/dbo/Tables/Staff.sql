﻿CREATE TABLE [dbo].[Staff]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [BranchId] INT NOT NULL,
    [CredentialId] INT NOT NULL,
    [FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[OtherName] NVARCHAR(50) NOT NULL,
    [MobilePhone] VARCHAR(50) NULL,
	[Dob] DATE NULL,
	[UtcCreated] DATETIME2(0) NOT NULL DEFAULT(GETUTCDATE()),
	[UtcUpdated] DATETIME2(0) NOT NULL DEFAULT(GETUTCDATE()),    
	[Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
    CONSTRAINT [FK_Staff_Branch] FOREIGN KEY ([BranchId]) REFERENCES [dbo].[Branch]([Id]),
    CONSTRAINT [FK_Staff_Credential] FOREIGN KEY ([CredentialId]) REFERENCES [dbo].[Credential]([Id])
)