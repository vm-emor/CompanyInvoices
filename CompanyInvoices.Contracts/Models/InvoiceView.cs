using System.Collections.Generic;
using System.Linq;

namespace CompanyInvoices.Contracts.Models;

public class InvoiceView : InvoiceBase
{
    public int Id { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public List<InvoiceItemView> Items { get; set; } = new();
    public decimal TotalAmount => Items.Sum(x => x.LineTotal);
}
