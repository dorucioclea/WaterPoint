CREATE TABLE [dbo].[CustomerOrganization]
(
    [OrganizationId] INT NOT NULL,
    [CustomerId] INT NOT NULL,
    CONSTRAINT [FK_CustomerOrganization_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization]([Id]),
    CONSTRAINT [FK_CustomerOrganization_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer]([Id]), 
    CONSTRAINT [PK_CustomerOrganization] PRIMARY KEY ([OrganizationId], [CustomerId])
)
