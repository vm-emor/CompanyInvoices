using System.Threading.Tasks;

namespace CompanyInvoices.Abstractions.Interfaces;

public interface IUserRepository
{
    Task<(int UserId, string UserName, string PasswordHash)?> GetByLoginAsync(string login);
}
