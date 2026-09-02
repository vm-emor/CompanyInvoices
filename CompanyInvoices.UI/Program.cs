using System;
using System.Windows.Forms;

namespace CompanyInvoices.UI;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Forms.LoginForm());
    }
}
