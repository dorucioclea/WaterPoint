if(select count(*) from BannerType) = 0 begin
    declare @shopid int = (select Id from dbo.shop where name = 'water point')
    insert into VariantType (Name, ShopId) values ('MainPage', @shopid)    
end
go