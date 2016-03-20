CREATE PROCEDURE [dbo].[List_CustomerAddesses_By_CustomerId]
    @organizationid INT,
    @customerid INT,
    @isdeleted BIT
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
	  ,ca.CustomerId
	  ,ca.IsPostAddress
	  ,ca.IsPrimary
    FROM
        [dbo].[Address] a
        JOIN [dbo].[CustomerAddress] ca ON a.Id = ca.AddressId AND ca.CustomerId = @customerid
    WHERE
        a.[OrganizationId] = @organizationid
        AND a.IsDeleted = @isdeleted
END
GO
