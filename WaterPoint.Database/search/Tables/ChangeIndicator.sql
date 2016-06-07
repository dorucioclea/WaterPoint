CREATE TABLE [search].[CustomerChangeIndicator]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [LastChangeId] INT NOT NULL
    CONSTRAINT [FK_search_CustomerChangeIndicator_search_CustomerChange] FOREIGN KEY ([LastChangeId]) REFERENCES [search].[CustomerChange] ([Id])
)
