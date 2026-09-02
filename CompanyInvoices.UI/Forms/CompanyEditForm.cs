using System.Windows.Forms;
using CompanyInvoices.Core.Models;
using CompanyInvoices.UI.Services;

namespace CompanyInvoices.UI.Forms;

public class CompanyEditForm : Form
{
    public CompanyEditForm(ApiClient apiClient, CompanyView? company = null)
    {
        Text = company is null ? "Create Company" : "Edit Company";
        Width = 500;
        Height = 300;
    }
}
