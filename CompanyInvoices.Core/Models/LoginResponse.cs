using System;

namespace CompanyInvoices.Core.Models;

public class LoginResponse
{
    public int UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public DateTime ExpiresAt { get; set; }
}
