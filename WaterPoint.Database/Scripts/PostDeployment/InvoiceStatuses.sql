MERGE INTO dbo.InvoiceStatus AS i
USING
(
	SELECT 1 AS Id, N'草稿' AS [Description]
    UNION ALL
    SELECT 2 AS Id, N'已发送' AS [Description]
    UNION ALL
    SELECT 3 AS Id, N'已取消' AS [Description]
    UNION ALL
    SELECT 4 AS Id, N'已认可' AS [Description]
) AS s
ON 	i.Id = s.Id

WHEN MATCHED THEN UPDATE SET [Description] = S.[Description]

WHEN NOT MATCHED BY TARGET THEN
	INSERT (Id, [Description])
	VALUES (s.Id, S.[Description])

WHEN NOT MATCHED BY SOURCE THEN DELETE;
GO
