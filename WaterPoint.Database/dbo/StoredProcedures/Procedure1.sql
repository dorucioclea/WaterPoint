CREATE PROCEDURE [dbo].[List_CustomerContacts_By_CustomerId]
    @organizationid INT,
    @customerid INT
AS
SET NOCOUNT ON;
BEGIN
    SELECT
       con.[Id]
      ,con.[OrganizationId]
      ,con.[FirstName]
      ,con.[LastName]
      ,con.[OtherName]
      ,con.[Phone]
      ,con.[MobilePhone]
      ,con.[Email]
      ,con.[IsDeleted]
      ,con.[Version]
      ,con.[UtcCreated]
      ,con.[UtcUpdated]
      ,con.[Uid]
    FROM
        [dbo].[Contact] con
        JOIN [dbo].[CustomerContact] cc ON con.Id = cc.ContactId AND cc.CustomerId = @customerid
    WHERE
        con.[OrganizationId] = @organizationId
        AND con.IsDeleted = 0
END
GO
