CREATE OR ALTER PROCEDURE sp_Company_GetById
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id, Name, TaxNumber, Address, Email
    FROM Companies
    WHERE Id = @Id;
END
