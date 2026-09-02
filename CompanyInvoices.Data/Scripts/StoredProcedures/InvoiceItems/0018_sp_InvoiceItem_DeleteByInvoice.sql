CREATE OR ALTER PROCEDURE sp_InvoiceItem_DeleteByInvoice
    @InvoiceId INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM InvoiceItems WHERE InvoiceId = @InvoiceId;
END
