CREATE PROCEDURE [dbo].[List_Customers_Paginated_WithSearch]
    @orgid INT,
    @offset INT,
    @pageSize INT,
    @orderby INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        c.[Id] ,
        c.[OrganizationId] ,
        c.[CustomerTypeId] ,
        c.[IsProspect] ,
        c.[Gender] ,
        c.[Code] ,
        c.[FirstName] ,
        c.[LastName] ,
        c.[OtherName] ,
        c.[Phone] ,
        c.[MobilePhone] ,
        c.[Email] ,
        c.[Dob] ,
        c.[IsDeleted] ,
        c.[InvoiceCustomerId] ,
        c.[Version] ,
        c.[Uid] ,
        c.[UtcCreated] ,
        c.[UtcUpdated] ,
        [TotalCount]
    FROM
        [dbo].[Customer] c
        CROSS APPLY(
            SELECT COUNT(*) TotalCount
            FROM
                [dbo].[Customer] c
            WHERE
                (((c.[OrganizationId] = @orgid) AND (c.[IsDeleted] = 0)) AND (c.[IsProspect] = 0))
        )[Count]
    WHERE
        (((c.[OrganizationId] = @orgid) AND (c.[IsDeleted] = 0)) AND (c.[IsProspect] = 0))
    ORDER BY @orderby
    OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY

END
