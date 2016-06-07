CREATE TABLE [search].[CustomerChange]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [CustomerId] INT NOT NULL,
    [UtcCreated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME())
    CONSTRAINT [FK_search_CustomerChange_dbo_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] (Id)
)
