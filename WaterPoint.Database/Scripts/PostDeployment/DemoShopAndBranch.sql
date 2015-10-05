/* Organization */
if (select count(*) from Organization) = 0 begin
    insert into dbo.Organization (Name, CountryId, IsActive) values ('Water Point', 1, 1)
end

/* Branch */
if (select count(*) from Branch) = 0 begin
    insert into dbo.Branch (Name, IsActive, IsMainBranch, OrganizationId) values ('Water Point', 1, 1, (select Id from dbo.Organization where name = 'Water Point'))
end
go