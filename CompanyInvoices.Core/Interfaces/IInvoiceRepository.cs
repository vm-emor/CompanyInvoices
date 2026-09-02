using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyInvoices.Core.Models;

namespace CompanyInvoices.Core.Interfaces;

public interface IInvoiceRepository
{
    Task<IEnumerable<InvoiceView>> GetAllAsync();
    Task<InvoiceView?> GetByIdAsync(int id);
    Task<IEnumerable<InvoiceView>> GetByCompanyAsync(int companyId);
    Task<bool> NumberExistsAsync(string number, int? excludeId = null);
    Task<int> InsertAsync(InvoiceEdit invoice);
    Task UpdateAsync(int id, InvoiceEdit invoice);
    Task DeleteAsync(int id);
}
