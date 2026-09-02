namespace CompanyInvoices.Core.Models;

public class PermissionView
{
    public int Id { get; set; }
    public string ObjectCode { get; set; } = string.Empty;
    public string ObjectName { get; set; } = string.Empty;
    public string PermissionType { get; set; } = string.Empty;
    public string PermissionTypeName { get; set; } = string.Empty;
}
