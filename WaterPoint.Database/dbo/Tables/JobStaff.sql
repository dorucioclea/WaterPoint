CREATE TABLE [dbo].[JobStaff]
(
    [JobId] INT NOT NULL,
    [StaffId] INT NOT NULL,
    [LastChangeOrganizationUserId] INT NULL,
    PRIMARY KEY ([JobId], [StaffId]),
    CONSTRAINT [FK_dbo_JobStaff_dbo_Job] FOREIGN KEY ([JobId]) REFERENCES [dbo].[Job]([Id]),
    CONSTRAINT [FK_dbo_JobStaff_dbo_Staff] FOREIGN KEY ([StaffId]) REFERENCES [dbo].[Staff]([Id]),
    CONSTRAINT [FK_dbo_JobStaff_dbo_OrganizationUser] FOREIGN KEY ([LastChangeOrganizationUserId]) REFERENCES [dbo].[OrganizationUser]([Id])
)
