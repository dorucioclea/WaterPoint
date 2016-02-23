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
    FROM
        [dbo].[Address] a
        JOIN [dbo].[CustomerContact] cc ON a.Id = cc.ContactId AND cc.CustomerId = @customerid
    WHERE
        a.[OrganizationId] = @organizationId
        AND a.IsDeleted = @isdeleted
END
GO
