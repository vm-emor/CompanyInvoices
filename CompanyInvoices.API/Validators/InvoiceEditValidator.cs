using CompanyInvoices.Abstractions.Interfaces;
using CompanyInvoices.Contracts.Models;
using FluentValidation;

namespace CompanyInvoices.API.Validators;

public class InvoiceEditValidator : AbstractValidator<InvoiceEdit>
{
    public InvoiceEditValidator(ICompanyRepository companies, IInvoiceRepository invoices)
    {
        RuleFor(x => x.CompanyId)
            .GreaterThan(0)
            .MustAsync(async (companyId, cancellation) => await companies.ExistsAsync(companyId))
            .WithMessage("Company does not exist.");

        RuleFor(x => x.Number)
            .NotEmpty()
            .MaximumLength(50)
            .MustAsync(async (model, number, cancellation) => !await invoices.NumberExistsAsync(number))
            .WithMessage("Invoice number already exists.");

        RuleFor(x => x.InvoiceDate)
            .LessThanOrEqualTo(DateTime.Today);

        RuleFor(x => x.Items)
            .NotNull()
            .Must(x => x.Count > 0).WithMessage("At least one invoice item is required.");

        RuleForEach(x => x.Items).SetValidator(new InvoiceItemEditValidator());
    }
}
