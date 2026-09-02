CREATE OR ALTER PROCEDURE sp_User_GetByLogin
    @Login NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id AS UserId,
           Name AS UserName,
           PasswordHash
    FROM Users
    WHERE Login = @Login;
END
