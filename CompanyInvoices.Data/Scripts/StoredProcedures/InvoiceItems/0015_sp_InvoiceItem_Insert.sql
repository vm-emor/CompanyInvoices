CREATE OR ALTER PROCEDURE sp_InvoiceItem_Insert
    @InvoiceId INT,
    @Description NVARCHAR(500),
    @Quantity DECIMAL(18,2),
    @UnitPrice DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO InvoiceItems (InvoiceId, Description, Quantity, UnitPrice)
    VALUES (@InvoiceId, @Description, @Quantity, @UnitPrice);

    SELECT CAST(SCOPE_IDENTITY() AS INT);
END
