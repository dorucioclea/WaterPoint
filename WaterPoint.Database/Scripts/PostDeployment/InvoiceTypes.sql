MERGE INTO dbo.InvoiceType AS i
USING
(
	SELECT 1 AS Id, N'帐单' AS [Description]
	UNION ALL
	SELECT 2 AS Id, N'进展账单' AS [Description]
    UNION ALL
    SELECT 3 AS Id, N'杂项账单' AS [Description]
) AS s
ON 	i.Id = s.Id

WHEN MATCHED THEN UPDATE SET [Description] = S.[Description]

WHEN NOT MATCHED BY TARGET THEN
	INSERT (Id, [Description])
	VALUES (s.Id, S.[Description])

WHEN NOT MATCHED BY SOURCE THEN DELETE;
GO
