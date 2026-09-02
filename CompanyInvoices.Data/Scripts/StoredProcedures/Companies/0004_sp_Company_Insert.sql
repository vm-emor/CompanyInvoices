CREATE OR ALTER PROCEDURE sp_Company_Insert
    @Name NVARCHAR(200),
    @TaxNumber NVARCHAR(50),
    @Address NVARCHAR(500),
    @Email NVARCHAR(200) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Companies (Name, TaxNumber, Address, Email)
    VALUES (@Name, @TaxNumber, @Address, @Email);

    SELECT CAST(SCOPE_IDENTITY() AS INT);
END
