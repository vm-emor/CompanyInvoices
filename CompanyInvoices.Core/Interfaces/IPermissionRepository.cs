using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyInvoices.Core.Models;

namespace CompanyInvoices.Core.Interfaces;

public interface IPermissionRepository
{
    Task<IEnumerable<UserPermission>> GetUserPermissionsAsync(int userId);
    Task<IEnumerable<PermissionView>> GetByUserAsync(int userId);
    Task<IEnumerable<SecurityObjectView>> GetSecurityObjectsAsync();
    Task<IEnumerable<PermissionTypeView>> GetPermissionTypesAsync();
    Task AddAsync(PermissionEdit permission);
    Task DeleteAsync(int permissionId);
}
