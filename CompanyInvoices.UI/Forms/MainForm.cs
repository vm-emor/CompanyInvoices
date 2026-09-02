using System.Windows.Forms;
using CompanyInvoices.UI.Services;

namespace CompanyInvoices.UI.Forms;

public class MainForm : Form
{
    public MainForm(ApiClient apiClient)
    {
        Text = "CompanyInvoices";
        Width = 800;
        Height = 600;

        var companiesButton = new Button { Left = 20, Top = 20, Width = 150, Text = "Companies" };
        var invoicesButton = new Button { Left = 180, Top = 20, Width = 150, Text = "Invoices" };

        companiesButton.Click += (_, _) => new CompanyListForm(apiClient).ShowDialog(this);
        invoicesButton.Click += (_, _) => new InvoiceListForm(apiClient).ShowDialog(this);

        Controls.Add(companiesButton);
        Controls.Add(invoicesButton);
    }
}
