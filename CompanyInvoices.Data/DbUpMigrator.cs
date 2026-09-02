using DbUp;

namespace CompanyInvoices.Data;

public static class DbUpMigrator
{
    public static void Migrate(string connectionString)
    {
        EnsureDatabase.For.SqlDatabase(connectionString);

        var upgrader = DeployChanges.To
            .SqlDatabase(connectionString)
            .WithScriptsEmbeddedInAssembly(typeof(DbUpMigrator).Assembly)
            .LogToConsole()
            .Build();

        upgrader.PerformUpgrade();
    }
}
