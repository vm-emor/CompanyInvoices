CREATE OR ALTER PROCEDURE sp_Invoice_Insert
    @CompanyId INT,
    @Number NVARCHAR(50),
    @InvoiceDate DATETIME2,
    @TotalAmount DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Invoices (CompanyId, Number, InvoiceDate, TotalAmount)
    VALUES (@CompanyId, @Number, @InvoiceDate, @TotalAmount);

    SELECT CAST(SCOPE_IDENTITY() AS INT);
END
