﻿/* Shop */
if (select count(*) from shop) = 0 begin
    insert into dbo.Shop (Name, IsActive) values ('Water Point', 1)
end
go

/* Branch */
if (select count(*) from Branch) = 0 begin
    insert into dbo.Branch (Name, IsActive, IsMainBranch, ShopId) values ('Water Point', 1, 1, (select Id from dbo.Shop where name = 'Water Point'))
end
go

/* Category */
if (SELECT COUNT(*) FROM dbo.Brand) = 0
    declare @shop_id int = (select id from shop where name = 'water point')
    BEGIN
        INSERT INTO dbo.Brand (Name, ShopId) VALUES ('Brand A', @shop_id, 0, 1) 
        INSERT INTO dbo.Brand (Name, ShopId) VALUES ('Brand B', @shop_id, 0, 1) 
        INSERT INTO dbo.Brand (Name, ShopId) VALUES ('Brand C', @shop_id, 0, 1) 
        INSERT INTO dbo.Brand (Name, ShopId) VALUES ('Brand D', @shop_id, 0, 1) 
    END
go

/* Category */
if (SELECT COUNT(*) FROM dbo.Category) = 0
    declare @shop_id int = (select id from shop where name = 'water point')
    BEGIN
        INSERT INTO dbo.Category (Name, ShopId, IsDeleted, IsActive) VALUES ('Bliaut', @shop_id, 0, 1) 
        INSERT INTO dbo.Category (Name, ShopId, IsDeleted, IsActive) VALUES ('Chemise', @shop_id, 0, 1) 
        INSERT INTO dbo.Category (Name, ShopId, IsDeleted, IsActive) VALUES ('Can-can dress', @shop_id, 0, 1) 
        INSERT INTO dbo.Category (Name, ShopId, IsDeleted, IsActive) VALUES ('Pantalettes', @shop_id, 0, 1) 
    END
go

/* Product */
if(SELECT COUNT(*) FROM dbo.Product) = 0
    BEGIN
        DECLARE @bliaut INT 
        SET @bliaut = (SELECT Id FROM dbo.Category WHERE Name = 'Bliaut')

        DECLARE @chemise INT 
        SET @chemise = (SELECT Id FROM dbo.Category WHERE Name = 'Chemise')

        DECLARE @dress INT 
        SET @dress = (SELECT Id FROM dbo.Category WHERE Name = 'Can-can dress')

        DECLARE @pantalettes INT 
        SET @pantalettes = (SELECT Id FROM dbo.Category WHERE Name = 'Pantalettes')

        declare @cat_counter int = 1            
        declare @shop_id int = (select id from shop where name = 'water point')
        declare @brand_id int = (select id from brand where name = 'Brand A')
        while @cat_counter <= 4 begin
            declare @counter int = 1    
            while @counter <= 20 begin                
                INSERT INTO dbo.Product (Name, BrandId, [Description],IsDeleted,IsActive,ShopId) 
                VALUES
                ('Product ' + CONVERT(VARCHAR, @counter), @brand_id, 'description for product ' + CONVERT(VARCHAR, @counter), 0, 1, @shop_id)

                DECLARE @pid INT = scope_identity()

                declare @pc int = 1
                                
                while @pc <= 4 begin
                    declare @random int = (select (ABS(CHECKSUM(NewId())) % 5))

                    if(@random = 1 and 
                        (select count(*) from productcategory where productid = @pid and categoryid = @bliaut) = 0)
                    begin              
                        insert into dbo.ProductCategory (ProductId, CategoryId) values (@pid, @bliaut)
                    end

                    if(@random = 2 and
                        (select count(*) from productcategory where productid = @pid and categoryid = @chemise) = 0)
                    begin
                        insert into dbo.ProductCategory (ProductId, CategoryId) values (@pid, @chemise)
                    end

                    if(@random = 3 and
                        (select count(*) from productcategory where productid = @pid and categoryid = @dress) = 0)
                    begin
                        insert into dbo.ProductCategory (ProductId, CategoryId) values (@pid, @dress)
                    end

                    if(@random = 4 and
                        (select count(*) from productcategory where productid = @pid and categoryid = @pantalettes) = 0)
                    begin
                        insert into dbo.ProductCategory (ProductId, CategoryId) values (@pid, @pantalettes)
                    end

                    set @pc = @pc + 1
                end                

                SET @counter = @counter + 1
            end
            set @cat_counter = @cat_counter + 1 
         end
    END
go

/* Sku */
if(select count(*) from sku) = 0 begin
    declare @branch_id int = (select b.id from branch b join shop s on b.ShopId = s.id where s.name = 'water point')
    select * into #tempproducts from product

    while (select count(*) from #tempproducts) > 0 begin
        declare @skupid int
        set @skupid = (select top 1 id from #tempproducts)
        declare @skurandom int = (select (ABS(CHECKSUM(NewId())) % 4))
        if(@skurandom = 0) begin
            set @skurandom = 1
        end

        while @skurandom > 0 begin
            insert into sku (productid, code, quantity, BranchId)
            values (@skupid, 'sku-' + convert(varchar, @skupid) + '-' + convert(varchar, @skurandom ), @skurandom, @branch_id)

            set @skurandom = @skurandom - 1
        end
        delete #tempproducts where id = @skupid 
    end
    drop table #tempproducts
end
go

/* Product flag*/
if(select count(*) from productflag) = 0 begin
    declare @featured int = (select id from flag where name = 'Featured')
    declare @sale int = (select id from flag where name = 'sale')
    declare @special int = (select id from flag where name = 'special')
    select top 10 id into #flagproducts from product order by newid()
    while(select count(*) from #flagproducts) > 0 begin
        declare @flagpid int = (select top 1 id from #flagproducts)
        declare @flagcounter int = 1
        while @flagcounter <= 3 begin
            declare @flagrandom int = (select (ABS(CHECKSUM(NewId())) % 4))
            if(@flagrandom = 1 and 
                (select count(*) from productflag where productid = @flagpid and flagid = @featured) = 0)
            begin              
                insert into dbo.productflag (ProductId, flagid) values (@flagpid, @featured)
            end

            if(@flagrandom = 2 and 
                (select count(*) from productflag where productid = @flagpid and flagid = @sale) = 0)
            begin              
                insert into dbo.productflag (ProductId, flagid) values (@flagpid, @sale)
            end

            if(@flagrandom = 3 and 
                (select count(*) from productflag where productid = @flagpid and flagid = @special) = 0)
            begin              
                insert into dbo.productflag (ProductId, flagid) values (@flagpid, @special)
            end

            set @flagcounter = @flagcounter + 1
        end
        delete #flagproducts where id = @flagpid
    end
    drop table #flagproducts
end
go

/* Product sku variants */