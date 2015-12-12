IF NOT EXISTS(SELECT TOP 1 * FROM [apiv1].[OAuthClient] WHERE [Name] = 'MainApplication') BEGIN
	INSERT INTO [apiv1].[OAuthClient]
		([ClientId], [ClientSecret], [Name], [IsInternal])
	VALUES
		('abcdefg', '123456', 'MainApplication', 1)
END