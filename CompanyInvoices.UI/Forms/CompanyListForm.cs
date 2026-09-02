using System.Linq;
using System.Windows.Forms;
using CompanyInvoices.UI.Services;

namespace CompanyInvoices.UI.Forms;

public class CompanyListForm : Form
{
    private readonly ApiClient _apiClient;
    private readonly DataGridView _grid = new() { Dock = DockStyle.Fill, AutoGenerateColumns = true };

    public CompanyListForm(ApiClient apiClient)
    {
        _apiClient = apiClient;
        Text = "Companies";
        Width = 800;
        Height = 500;
        Controls.Add(_grid);

        Load += async (_, _) =>
        {
            var items = await _apiClient.GetCompaniesAsync();
            _grid.DataSource = items.ToList();
        };
    }
}
