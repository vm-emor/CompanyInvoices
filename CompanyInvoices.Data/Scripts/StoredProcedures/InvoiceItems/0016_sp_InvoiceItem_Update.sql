CREATE OR ALTER PROCEDURE sp_InvoiceItem_Update
    @Id INT,
    @Description NVARCHAR(500),
    @Quantity DECIMAL(18,2),
    @UnitPrice DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE InvoiceItems
    SET Description = @Description,
        Quantity = @Quantity,
        UnitPrice = @UnitPrice
    WHERE Id = @Id;
END
