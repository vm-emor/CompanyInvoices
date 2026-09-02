using System.Windows.Forms;
using CompanyInvoices.UI.Services;

namespace CompanyInvoices.UI.Forms;

public class LoginForm : Form
{
    private readonly TextBox _loginTextBox = new() { Left = 20, Top = 20, Width = 240 };
    private readonly TextBox _passwordTextBox = new() { Left = 20, Top = 60, Width = 240, UseSystemPasswordChar = true };
    private readonly Button _loginButton = new() { Left = 20, Top = 100, Width = 100, Text = "Login" };
    private readonly ApiClient _apiClient = new("https://localhost:5001/");

    public LoginForm()
    {
        Text = "Login";
        Width = 320;
        Height = 200;

        Controls.Add(_loginTextBox);
        Controls.Add(_passwordTextBox);
        Controls.Add(_loginButton);

        _loginButton.Click += async (_, _) =>
        {
            var response = await _apiClient.LoginAsync(new CompanyInvoices.Core.Models.LoginRequest
            {
                Login = _loginTextBox.Text,
                Password = _passwordTextBox.Text
            });

            if (response is null)
            {
                MessageBox.Show("Login failed.");
                return;
            }

            _apiClient.SetToken(response.Token);
            Hide();
            new MainForm(_apiClient).ShowDialog(this);
            Close();
        };
    }
}
