CREATE OR ALTER PROCEDURE sp_Permission_Delete
    @PermissionId INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Permissions WHERE Id = @PermissionId;
END
