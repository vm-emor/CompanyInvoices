using System.Data;
using CompanyInvoices.Abstractions.Interfaces;
using Dapper;

namespace CompanyInvoices.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DbConnectionFactory _factory;

    public UserRepository(DbConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<(int UserId, string UserName, string PasswordHash)?> GetByLoginAsync(string login)
    {
        using var conn = _factory.Create();
        var row = await conn.QuerySingleOrDefaultAsync<(int UserId, string UserName, string PasswordHash)>(
            "sp_User_GetByLogin",
            new { Login = login },
            commandType: CommandType.StoredProcedure);

        return row.Equals(default((int, string, string))) ? null : row;
    }
}
