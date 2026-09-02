using CompanyInvoices.Core.Models;
using FluentValidation;

namespace CompanyInvoices.API.Validators;

public class InvoiceItemEditValidator : AbstractValidator<InvoiceItemEdit>
{
    public InvoiceItemEditValidator()
    {
        RuleFor(x => x.Description).NotEmpty().MaximumLength(500);
        RuleFor(x => x.Quantity).GreaterThan(0);
        RuleFor(x => x.UnitPrice).GreaterThan(0);
    }
}
