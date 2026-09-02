CREATE OR ALTER PROCEDURE sp_Company_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id, Name, TaxNumber, Address, Email
    FROM Companies
    ORDER BY Name;
END
