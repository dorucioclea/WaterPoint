CREATE TABLE [dbo].[Organization]
(
	[Id] INT NOT NULL IDENTITY,
	[Name] NVARCHAR(150) NOT NULL,
	[DisplayName] NVARCHAR(150) NULL,
	[LogoImageId] INT NULL,	
    [InvoiceDueDate] INT NULL DEFAULT(15),
    [InvoiceDueDaysAfterInvoiced] INT NULL, 
    [TaxCode] NVARCHAR(100) NULL, 
    [InvoiceNote] NVARCHAR(500) NULL, 
	[PurchaseOrderNote] NVARCHAR(500) NULL,
	[InvoiceNumberCode] NVARCHAR(10),
	[PurchaseOrderNumberCode] NVARCHAR(10),
	[Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
	CONSTRAINT [PK_Organization] PRIMARY KEY ([Id])
)
