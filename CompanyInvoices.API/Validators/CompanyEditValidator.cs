using CompanyInvoices.Contracts.Models;
using FluentValidation;

namespace CompanyInvoices.API.Validators;

public class CompanyEditValidator : AbstractValidator<CompanyEdit>
{
    public CompanyEditValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
        RuleFor(x => x.TaxNumber).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Address).NotEmpty().MaximumLength(500);
        RuleFor(x => x.Email).MaximumLength(200).EmailAddress().When(x => !string.IsNullOrWhiteSpace(x.Email));
    }
}
