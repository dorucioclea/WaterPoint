CREATE TABLE [dbo].[CustomerContact]
(
    [CustomerId] INT NOT NULL ,
    [ContactId] INT NOT NULL,
    [IsPrimary] BIT NOT NULL DEFAULT 0,
    PRIMARY KEY ([ContactId], [CustomerId]),
    CONSTRAINT [FK_dbo_CustomerContact_dbo_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer]([Id]),
    CONSTRAINT [FK_dbo_CustomerContact_dbo_Contact] FOREIGN KEY ([ContactId]) REFERENCES [dbo].[Contact]([Id])
)
