using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyInvoices.Contracts.Models;

namespace CompanyInvoices.Abstractions.Interfaces;

public interface IInvoiceItemRepository
{
    Task<IEnumerable<InvoiceItemView>> GetByInvoiceAsync(int invoiceId);
    Task<int> InsertAsync(int invoiceId, InvoiceItemEdit item);
    Task UpdateAsync(int id, InvoiceItemEdit item);
    Task DeleteAsync(int id);
    Task DeleteByInvoiceAsync(int invoiceId);
}
