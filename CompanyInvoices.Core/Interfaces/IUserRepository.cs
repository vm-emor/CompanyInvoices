using System.Threading.Tasks;
using CompanyInvoices.Core.Models;

namespace CompanyInvoices.Core.Interfaces;

public interface IUserRepository
{
    Task<(int UserId, string UserName, string PasswordHash)?> GetByLoginAsync(string login);
}
