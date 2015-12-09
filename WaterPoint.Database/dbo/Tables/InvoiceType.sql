CREATE TABLE [dbo].[InvoiceType]
(
    [Id] INT NOT NULL,
    [Description] NVARCHAR(50) NOT NULL,
    CONSTRAINT [PK_dbo_InvoiceType_Id] PRIMARY KEY CLUSTERED (Id ASC),
)
