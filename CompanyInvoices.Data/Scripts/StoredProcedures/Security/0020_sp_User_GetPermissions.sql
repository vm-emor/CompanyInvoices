CREATE OR ALTER PROCEDURE sp_User_GetPermissions
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT p.Id AS PermissionId,
           so.Code AS ObjectCode,
           pt.Code AS PermissionType
    FROM Permissions p
    JOIN SecurityObjects so ON so.Id = p.SecurityObjectId
    JOIN PermissionTypes pt ON pt.Id = p.PermissionTypeId
    WHERE p.UserId = @UserId;
END
