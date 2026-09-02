CREATE OR ALTER PROCEDURE sp_Company_Update
    @Id INT,
    @Name NVARCHAR(200),
    @TaxNumber NVARCHAR(50),
    @Address NVARCHAR(500),
    @Email NVARCHAR(200) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Companies
    SET Name = @Name,
        TaxNumber = @TaxNumber,
        Address = @Address,
        Email = @Email
    WHERE Id = @Id;
END
