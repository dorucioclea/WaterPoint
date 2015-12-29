CREATE FUNCTION [dbo].[IntTextToTable]
(
	@intTextToTable VARCHAR(MAX)
)
RETURNS @table TABLE
(
	Number INT
)
AS
BEGIN
	INSERT @table
	SELECT t.value('.', 'int') AS Number
	FROM
	(
		   SELECT CAST('<t>'+ REPLACE(@intTextToTable, ',', '</t><t>')+ '</t>' AS XML) AS x
	) AS t CROSS APPLY x.nodes('/t') AS x(t)

	RETURN
END
