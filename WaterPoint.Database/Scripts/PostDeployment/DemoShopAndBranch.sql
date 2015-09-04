/* Shop */
if (select count(*) from shop) = 0 begin
    insert into dbo.Shop (Name, CountryId, IsActive) values ('Water Point', 1, 1)
end

/* Branch */
if (select count(*) from Branch) = 0 begin
    insert into dbo.Branch (Name, IsActive, IsMainBranch, ShopId) values ('Water Point', 1, 1, (select Id from dbo.Shop where name = 'Water Point'))
end
go