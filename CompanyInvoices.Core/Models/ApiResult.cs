using System.Collections.Generic;

namespace CompanyInvoices.Core.Models;

public class ApiResult<T>
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
    public List<ApiValidationError> ValidationErrors { get; set; } = new();
}
