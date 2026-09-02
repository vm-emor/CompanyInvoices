namespace CompanyInvoices.Core.Models;

public class InvoiceItemView : InvoiceItemBase
{
    public int Id { get; set; }
    public decimal LineTotal => Quantity * UnitPrice;
}
