CREATE PROCEDURE [dbo].[Get_CustomerAddress_By_CustomerId]
    @organizationId INT,
    @customerid INT,
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
    FROM
        [dbo].[Address] a
        JOIN [dbo].[CustomerAddress] ca ON a.Id = ca.AddressId AND ca.CustomerId = @customerid
    WHERE
        a.[OrganizationId] = @organizationId
        AND a.Id = @id
        AND a.IsDeleted = 0
END
GO
