CREATE OR ALTER PROCEDURE sp_Invoice_NumberExists
    @Number NVARCHAR(50),
    @ExcludeId INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT CAST(CASE WHEN EXISTS (
        SELECT 1
        FROM Invoices
        WHERE Number = @Number
          AND (@ExcludeId IS NULL OR Id <> @ExcludeId)
    ) THEN 1 ELSE 0 END AS BIT);
END
