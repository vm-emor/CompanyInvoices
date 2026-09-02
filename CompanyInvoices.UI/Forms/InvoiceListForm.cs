using System.Windows.Forms;
using CompanyInvoices.UI.Services;

namespace CompanyInvoices.UI.Forms;

public class InvoiceListForm : Form
{
    public InvoiceListForm(ApiClient apiClient)
    {
        Text = "Invoices";
        Width = 900;
        Height = 500;
    }
}
