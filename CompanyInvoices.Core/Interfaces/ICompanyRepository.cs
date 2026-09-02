using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyInvoices.Core.Models;

namespace CompanyInvoices.Core.Interfaces;

public interface ICompanyRepository
{
    Task<IEnumerable<CompanyView>> GetAllAsync();
    Task<CompanyView?> GetByIdAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task<int> InsertAsync(CompanyEdit company);
    Task UpdateAsync(int id, CompanyEdit company);
    Task DeleteAsync(int id);
}
