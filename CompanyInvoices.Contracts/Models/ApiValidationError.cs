using System.Collections.Generic;

namespace CompanyInvoices.Contracts.Models;

public class ApiValidationError
{
    public string PropertyName { get; set; } = string.Empty;
    public List<string> Errors { get; set; } = new();
}
