CREATE TABLE [dbo].[OrganizationUserPrivilege]
(
    [OrganizationUserId] INT NOT NULL ,
    [PrivilegeId] INT NOT NULL,
    PRIMARY KEY ([OrganizationUserId], [PrivilegeId]),
    CONSTRAINT [FK_OrganizationUserPrivilege_OrganizationUser] FOREIGN KEY ([OrganizationUserId]) REFERENCES [dbo].[OrganizationUser]([Id]),
    CONSTRAINT [FK_OrganizationUserPrivilege_Privilege] FOREIGN KEY ([PrivilegeId]) REFERENCES [dbo].[Privilege]([Id]),
)
