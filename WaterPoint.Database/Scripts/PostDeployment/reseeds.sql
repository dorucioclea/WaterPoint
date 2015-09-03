/*
Post-Deployment Script Template                            
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.        
 Use SQLCMD syntax to include a file in the post-deployment script.            
 Example:      :r .\myfile.sql                                
 Use SQLCMD syntax to reference a variable in the post-deployment script.        
 Example:      :setvar TableName MyTable                            
               SELECT * FROM [$(TableName)]                    
--------------------------------------------------------------------------------------
*/
IF(SELECT COUNT(*) FROM dbo.Product) = 0
    BEGIN
        DBCC checkident ('dbo.Product', reseed, 10000)
    END

IF(SELECT COUNT(*) FROM dbo.Category) = 0
    BEGIN
        DBCC checkident ('dbo.Category', reseed, 1000)
    END

IF(SELECT COUNT(*) FROM dbo.Customer) = 0
    BEGIN
        DBCC checkident ('dbo.Customer', reseed, 10000)
    END

IF(SELECT COUNT(*) FROM dbo.Sku) = 0
    BEGIN
        DBCC checkident ('dbo.Sku', reseed, 10000)
    END