using System.Data;
using CompanyInvoices.Abstractions.Interfaces;
using CompanyInvoices.Contracts.Models;
using Dapper;

namespace CompanyInvoices.Data.Repositories;

public class PermissionRepository : IPermissionRepository
{
    private readonly DbConnectionFactory _factory;

    public PermissionRepository(DbConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<IEnumerable<UserPermission>> GetUserPermissionsAsync(int userId)
    {
        using var conn = _factory.Create();
        return await conn.QueryAsync<UserPermission>("sp_User_GetPermissions", new { UserId = userId }, commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<PermissionView>> GetByUserAsync(int userId)
    {
        using var conn = _factory.Create();
        return await conn.QueryAsync<PermissionView>("sp_Permission_GetByUser", new { UserId = userId }, commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<SecurityObjectView>> GetSecurityObjectsAsync()
    {
        using var conn = _factory.Create();
        return await conn.QueryAsync<SecurityObjectView>("SELECT Id, Code, Name FROM SecurityObjects ORDER BY Name");
    }

    public async Task<IEnumerable<PermissionTypeView>> GetPermissionTypesAsync()
    {
        using var conn = _factory.Create();
        return await conn.QueryAsync<PermissionTypeView>("SELECT Id, Code, Name FROM PermissionTypes ORDER BY Name");
    }

    public async Task AddAsync(PermissionEdit permission)
    {
        using var conn = _factory.Create();
        await conn.ExecuteAsync("sp_Permission_Add", new
        {
            permission.UserId,
            permission.SecurityObjectId,
            permission.PermissionTypeId
        }, commandType: CommandType.StoredProcedure);
    }

    public async Task DeleteAsync(int permissionId)
    {
        using var conn = _factory.Create();
        await conn.ExecuteAsync("sp_Permission_Delete", new { PermissionId = permissionId }, commandType: CommandType.StoredProcedure);
    }
}
