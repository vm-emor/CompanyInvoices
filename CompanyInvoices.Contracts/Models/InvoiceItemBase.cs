namespace CompanyInvoices.Contracts.Models;

public abstract class InvoiceItemBase
{
    public string Description { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}
