MERGE INTO dbo.CostItemType AS i
USING
(
	SELECT 1 AS Id, N'普通商品' AS [Description], 1 AS [UnitOfMeasurementId]
    UNION ALL
    SELECT 2 AS Id, N'服务' AS [Description], 2 AS [UnitOfMeasurementId]
    UNION ALL
    SELECT 3 AS Id, N'出租商品' AS [Description], 2 AS [UnitOfMeasurementId]
) AS s
ON 	i.Id = s.Id

WHEN MATCHED THEN UPDATE SET [Description] = s.[Description]

WHEN NOT MATCHED BY TARGET THEN
	INSERT (Id, [Description])
	VALUES (s.Id, s.[Description])

WHEN NOT MATCHED BY SOURCE THEN DELETE;
GO
