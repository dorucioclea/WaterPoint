CREATE PROCEDURE [dbo].[Get_CustomerAddress_By_CustomerId]
    @organizationid INT,
    @customerid INT,
	@isdeleted BIT,
    @id INT
AS
SET NOCOUNT ON;
BEGIN
    SELECT
        a.[Id]
        ,a.[OrganizationId]
        ,a.[Street]
        ,a.[StreetExtraLine]
        ,a.[Suburb]
        ,a.[City]
        ,a.[Province]
        ,a.[PostCode]
        ,a.[CountryId]
        ,a.[IsDeleted]
        ,a.[Version]
		,ca.IsPostAddress
		,ca.IsPrimary
    FROM
        [dbo].[Address] a
        JOIN [dbo].[CustomerAddress] ca ON a.Id = ca.AddressId AND ca.CustomerId = @customerid
    WHERE
        a.[OrganizationId] = @organizationid
        AND a.Id = @id
		AND a.IsDeleted = @isdeleted
END
GO
