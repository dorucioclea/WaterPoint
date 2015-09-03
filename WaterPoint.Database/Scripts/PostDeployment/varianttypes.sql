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

MERGE INTO dbo.VariantType AS T
USING 
(
	SELECT 10 AS Id, 'Size' AS Name
	UNION ALL
	SELECT 11 AS Id, 'Colour' AS Name
    UNION ALL
	SELECT 12 AS Id, 'Weight' AS Name
) AS S 

ON 
	T.Id = S.Id

WHEN MATCHED THEN 
	UPDATE SET Name = S.Name

WHEN NOT MATCHED BY TARGET THEN 
	INSERT (Id, Name) 
    VALUES (S.Id, S.Name)

WHEN NOT MATCHED BY SOURCE THEN
	DELETE;
GO