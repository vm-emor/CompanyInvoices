namespace CompanyInvoices.Contracts.Models;

public class UserPermission
{
    public int PermissionId { get; set; }
    public string ObjectCode { get; set; } = string.Empty;
    public string PermissionType { get; set; } = string.Empty;
}
