﻿-- maintain jobledgertype data
--MERGE INTO dbo.TableClass AS T
--USING 
--(
--	SELECT 'VIP' AS Name
--	UNION ALL
--	SELECT 'Private room' AS Name
--) AS S 

--ON 
--	T.TableClassId = S.jobledgertype_id
--WHEN MATCHED THEN UPDATE SET name = S.Name, wip_control = S.wip_control, is_interim = S.is_interim, is_additional = S.is_additional
--WHEN NOT MATCHED BY TARGET THEN INSERT (jobledgertype_id, wip_control, is_interim, is_additional, name) 
--    VALUES (S.jobledgertype_id, S.wip_control, S.is_interim, S.is_additional, S.name)
--WHEN NOT MATCHED BY SOURCE THEN DELETE;
--GO