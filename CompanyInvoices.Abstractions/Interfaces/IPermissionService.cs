using System.Threading.Tasks;

namespace CompanyInvoices.Abstractions.Interfaces;

public interface IPermissionService
{
    Task<bool> HasPermissionAsync(int userId, string objectCode, string permissionType);
    void InvalidateCache(int userId);
}
