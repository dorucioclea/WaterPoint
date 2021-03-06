﻿MERGE INTO dbo.PriorityType AS T
USING
(
	SELECT 1 AS Id, N'立即处理' AS [Description]
	UNION ALL
	SELECT 2 AS Id, N'紧迫' AS [Description]
	UNION ALL
	SELECT 3 AS Id, N'尚不紧迫' AS [Description]
	UNION ALL
	SELECT 4 AS Id, N'可稍候' AS [Description]
    UNION ALL
	SELECT 5 AS Id, N'目前不重要' AS [Description]
) AS S

ON
	T.Id = S.Id

WHEN MATCHED THEN
	UPDATE SET [Description] = S.[Description]

WHEN NOT MATCHED BY TARGET THEN
	INSERT (Id, [Description])
    VALUES (S.Id, S.[Description])

WHEN NOT MATCHED BY SOURCE THEN
	DELETE;
GO
