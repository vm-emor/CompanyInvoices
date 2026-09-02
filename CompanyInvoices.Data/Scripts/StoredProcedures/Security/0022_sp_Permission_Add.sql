CREATE OR ALTER PROCEDURE sp_Permission_Add
    @UserId INT,
    @SecurityObjectId INT,
    @PermissionTypeId INT
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (
        SELECT 1
        FROM Permissions
        WHERE UserId = @UserId
          AND SecurityObjectId = @SecurityObjectId
          AND PermissionTypeId = @PermissionTypeId)
    BEGIN
        INSERT INTO Permissions (UserId, SecurityObjectId, PermissionTypeId)
        VALUES (@UserId, @SecurityObjectId, @PermissionTypeId);
    END
END
