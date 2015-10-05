if(select count(*) from BannerType) = 0 begin
    declare @Organizationid int = (select Id from dbo.Organization where name = 'water point')
    insert into VariantType (Name, OrganizationId) values ('MainPage', @Organizationid)    
end
go