INSERT INTO Users (Login, PasswordHash, Name)
VALUES ('admin', 'admin', 'Administrator');

INSERT INTO Permissions (UserId, SecurityObjectId, PermissionTypeId)
SELECT 1, so.Id, pt.Id
FROM SecurityObjects so
CROSS JOIN PermissionTypes pt;
