using System.Windows.Forms;
using CompanyInvoices.Core.Models;
using CompanyInvoices.UI.Services;

namespace CompanyInvoices.UI.Forms;

public class InvoiceEditForm : Form
{
    public InvoiceEditForm(ApiClient apiClient, InvoiceView? invoice = null)
    {
        Text = invoice is null ? "Create Invoice" : "Edit Invoice";
        Width = 700;
        Height = 500;
    }
}
