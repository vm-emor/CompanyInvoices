using CompanyInvoices.Contracts.Models;
using CompanyInvoices.UI.Services;
using System.Windows.Forms;

namespace CompanyInvoices.UI.Forms;

public class InvoiceEditForm : Form
{
    public InvoiceEditForm(ApiClient apiClient, InvoiceView invoice = null)
    {
        Text = invoice == null ? "Create Invoice" : "Edit Invoice";
        Width = 700;
        Height = 500;
    }
}
