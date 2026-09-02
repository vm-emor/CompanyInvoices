using CompanyInvoices.Core.Models;

namespace CompanyInvoices.API.Services;

public interface ITokenService
{
    LoginResponse Create(int userId, string userName);
}
