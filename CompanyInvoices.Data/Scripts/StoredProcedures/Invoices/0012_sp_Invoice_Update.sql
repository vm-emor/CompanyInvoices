CREATE OR ALTER PROCEDURE sp_Invoice_Update
    @Id INT,
    @CompanyId INT,
    @Number NVARCHAR(50),
    @InvoiceDate DATETIME2,
    @TotalAmount DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Invoices
    SET CompanyId = @CompanyId,
        Number = @Number,
        InvoiceDate = @InvoiceDate,
        TotalAmount = @TotalAmount
    WHERE Id = @Id;
END
