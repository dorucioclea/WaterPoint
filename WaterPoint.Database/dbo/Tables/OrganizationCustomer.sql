CREATE TABLE [dbo].[CustomerOrganization]
(
    [OrganizationId] INT NOT NULL,
    [CustomerId] INT NOT NULL,
    CONSTRAINT [FK_OrganizationCustomer_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization]([Id]),
    CONSTRAINT [FK_OrganizationCustomer_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer]([Id]),
    CONSTRAINT [PK_OrganizationCustomer] PRIMARY KEY ([OrganizationId], [CustomerId])
)
