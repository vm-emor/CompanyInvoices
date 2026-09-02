using System.Collections.Generic;

namespace CompanyInvoices.Contracts.Models;

public class ApiResult<T>
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public T Data { get; set; }
    public List<ApiValidationError> ValidationErrors { get; set; } = new();
}
