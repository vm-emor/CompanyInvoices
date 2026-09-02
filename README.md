# CompanyInvoices

Multi-project sample solution for company and invoice management.

## Projects

- `CompanyInvoices.Contracts` - shared API/UI models and result wrappers
- `CompanyInvoices.Abstractions` - server-side interfaces and abstractions
- `CompanyInvoices.Data` - Dapper repositories, DbUp migrator, SQL scripts
- `CompanyInvoices.API` - ASP.NET Core Web API, JWT auth, FluentValidation, permission checks
- `CompanyInvoices.UI` - WinForms client skeleton

## Architecture highlights

- Shared models follow `Base / Edit / View`
- JWT stores user identity only
- Permissions are loaded from database and can be cached
- Invoice total is calculated on the server
- SQL scripts are stored in the data project
- UI depends only on `Contracts`, not on repository abstractions

## Solution layout

```text
CompanyInvoices.sln
CompanyInvoices.Contracts/
CompanyInvoices.Abstractions/
CompanyInvoices.Data/
CompanyInvoices.API/
CompanyInvoices.UI/
```

## Running

1. Configure the SQL Server connection string in `CompanyInvoices.API/appsettings.json`.
2. Apply SQL scripts or hook up `DbUpMigrator` on startup.
3. Run the API project.
4. Run the WinForms UI project.

## Notes

This repository contains an initial skeleton intended to be extended.
