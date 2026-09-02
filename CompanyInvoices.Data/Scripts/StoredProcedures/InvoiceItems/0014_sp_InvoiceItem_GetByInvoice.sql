CREATE OR ALTER PROCEDURE sp_InvoiceItem_GetByInvoice
    @InvoiceId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id, Description, Quantity, UnitPrice
    FROM InvoiceItems
    WHERE InvoiceId = @InvoiceId
    ORDER BY Id;
END
