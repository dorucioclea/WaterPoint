CREATE TABLE [dbo].[PriorityType]
(
    [Id] INT NOT NULL,
    [Description] NVARCHAR(50) NOT NULL
    CONSTRAINT [PK_dbo_PriorityType_Id] PRIMARY KEY CLUSTERED (Id ASC),
)
