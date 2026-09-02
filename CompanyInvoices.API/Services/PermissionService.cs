using CompanyInvoices.Abstractions.Interfaces;
using CompanyInvoices.Contracts.Models;
using Microsoft.Extensions.Caching.Memory;

namespace CompanyInvoices.API.Services;

public class PermissionService : IPermissionService
{
    private readonly IPermissionRepository _repo;
    private readonly IMemoryCache _cache;
    private static readonly TimeSpan CacheDuration = TimeSpan.FromMinutes(5);

    public PermissionService(IPermissionRepository repo, IMemoryCache cache)
    {
        _repo = repo;
        _cache = cache;
    }

    public async Task<bool> HasPermissionAsync(int userId, string objectCode, string permissionType)
    {
        var permissions = await GetPermissionsAsync(userId);
        return permissions.Any(p => p.ObjectCode == objectCode && p.PermissionType == permissionType);
    }

    public void InvalidateCache(int userId)
    {
        _cache.Remove(GetKey(userId));
    }

    private async Task<IEnumerable<UserPermission>> GetPermissionsAsync(int userId)
    {
        if (_cache.TryGetValue(GetKey(userId), out IEnumerable<UserPermission> cached))
        {
            return cached;
        }

        var permissions = (await _repo.GetUserPermissionsAsync(userId)).ToList();
        _cache.Set(GetKey(userId), permissions, CacheDuration);
        return permissions;
    }

    private static string GetKey(int userId) => $"permissions_{userId}";
}
