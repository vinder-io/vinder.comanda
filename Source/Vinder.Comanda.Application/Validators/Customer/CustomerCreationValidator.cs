namespace Vinder.Comanda.Application.Validators.Customer;

public sealed class CustomerCreationValidator : AbstractValidator<CreateCustomerRequest>
{
    public CustomerCreationValidator()
    {
        RuleFor(customer => customer.Name)
            .NotEmpty()
            .WithMessage("name is required.")
            .MinimumLength(2)
            .WithMessage("name must have at least 2 characters.")
            .MaximumLength(100)
            .WithMessage("name must not exceed 100 characters.")
            .Matches(@"^[a-zA-ZÀ-ÿ0-9\s\.\-']+$")
            .WithMessage("name contains invalid characters.");

        RuleFor(customer => customer.Email)
            .NotEmpty()
            .WithMessage("email is required.")
            .EmailAddress()
            .WithMessage("invalid email format.")
            .MaximumLength(200)
            .WithMessage("email must not exceed 200 characters.");

        RuleFor(customer => customer.UserId)
            .NotEmpty()
            .WithMessage("userId is required.")
            .MaximumLength(100)
            .WithMessage("userId must not exceed 100 characters.")
            .Matches(@"^[a-zA-Z0-9\-_]+$")
            .WithMessage("userId contains invalid characters.");
    }
}