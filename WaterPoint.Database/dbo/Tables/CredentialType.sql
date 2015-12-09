CREATE TABLE [dbo].[CredentialType]
(
    [Id] INT NOT NULL IDENTITY,
    [Description] NVARCHAR(50) NOT NULL,
    CONSTRAINT [PK_dbo_CredentialType_Id] PRIMARY KEY CLUSTERED (Id ASC),
)
