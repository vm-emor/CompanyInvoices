using System.Collections.Generic;

namespace CompanyInvoices.Contracts.Models;

public class InvoiceEdit : InvoiceBase
{
    public List<InvoiceItemEdit> Items { get; set; } = new();
}
