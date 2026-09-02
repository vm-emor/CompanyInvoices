namespace CompanyInvoices.Contracts.Models;

public class PermissionEdit
{
    public int UserId { get; set; }
    public int SecurityObjectId { get; set; }
    public int PermissionTypeId { get; set; }
}
