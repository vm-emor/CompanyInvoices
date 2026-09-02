using System;

namespace CompanyInvoices.Contracts.Models;

public abstract class InvoiceBase
{
    public int CompanyId { get; set; }
    public string Number { get; set; } = string.Empty;
    public DateTime InvoiceDate { get; set; }
}
