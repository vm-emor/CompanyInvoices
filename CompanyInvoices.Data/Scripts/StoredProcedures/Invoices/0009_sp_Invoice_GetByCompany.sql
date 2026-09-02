CREATE OR ALTER PROCEDURE sp_Invoice_GetByCompany
    @CompanyId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT i.Id,
           i.CompanyId,
           c.Name AS CompanyName,
           i.Number,
           i.InvoiceDate,
           i.TotalAmount
    FROM Invoices i
    JOIN Companies c ON c.Id = i.CompanyId
    WHERE i.CompanyId = @CompanyId
    ORDER BY i.InvoiceDate DESC, i.Id DESC;
END
