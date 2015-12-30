CREATE TABLE [dbo].[InvoiceStatus]
(
    [Id] INT NOT NULL,
    [Description] NVARCHAR(50) NOT NULL,
    CONSTRAINT [PK_dbo_InvoiceStatus_Id] PRIMARY KEY CLUSTERED (Id ASC),
)
