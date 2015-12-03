CREATE TABLE [dbo].[StaffPrivilege]
(
    [StaffId] INT NOT NULL ,
    [PrivilegeId] INT NOT NULL,
    PRIMARY KEY ([StaffId], [PrivilegeId]),
    CONSTRAINT [FK_StaffPrivilege_Staff] FOREIGN KEY ([StaffId]) REFERENCES [dbo].[Staff]([Id]),
    CONSTRAINT [FK_StaffPrivilege_Privilege] FOREIGN KEY ([PrivilegeId]) REFERENCES [dbo].[Privilege]([Id]),
)
