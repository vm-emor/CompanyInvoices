CREATE OR ALTER PROCEDURE sp_Permission_GetByUser
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT p.Id,
           so.Code AS ObjectCode,
           so.Name AS ObjectName,
           pt.Code AS PermissionType,
           pt.Name AS PermissionTypeName
    FROM Permissions p
    JOIN SecurityObjects so ON so.Id = p.SecurityObjectId
    JOIN PermissionTypes pt ON pt.Id = p.PermissionTypeId
    WHERE p.UserId = @UserId;
END
