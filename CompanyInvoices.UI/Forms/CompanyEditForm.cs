using CompanyInvoices.Contracts.Models;
using CompanyInvoices.UI.Services;
using System.Windows.Forms;

namespace CompanyInvoices.UI.Forms;

public class CompanyEditForm : Form
{
    public CompanyEditForm(ApiClient apiClient, CompanyView company = null)
    {
        Text = company == null ? "Create Company" : "Edit Company";
        Width = 500;
        Height = 300;
    }
}
