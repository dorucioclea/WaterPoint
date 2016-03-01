CREATE PROCEDURE [dbo].[List_CustomerContacts_By_CustomerId]
    @organizationid INT,
    @customerid INT,
    @isdeleted BIT
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
      ,cc.[IsPrimary]
    FROM
        [dbo].[Contact] con
        JOIN [dbo].[CustomerContact] cc ON con.Id = cc.ContactId AND cc.CustomerId = @customerid
    WHERE
        con.[OrganizationId] = @organizationid
        AND con.IsDeleted = @isdeleted
END
GO
