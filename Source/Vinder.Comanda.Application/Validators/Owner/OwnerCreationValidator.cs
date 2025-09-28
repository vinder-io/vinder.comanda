namespace Vinder.Comanda.Application.Validators.Owner;

public sealed class OwnerCreationValidator : AbstractValidator<CreateOwnerRequest>
{
    public OwnerCreationValidator()
    {
        RuleFor(owner => owner.Name)
            .NotEmpty()
            .WithMessage("name is required.")
            .MinimumLength(3)
            .WithMessage("name must have at least 3 characters.")
            .MaximumLength(100)
            .WithMessage("name must not exceed 100 characters.")
            .Matches(@"^[a-zA-ZÀ-ÿ0-9\s\.\-']+$")
            .WithMessage("name contains invalid characters.");

        RuleFor(owner => owner.Email)
            .NotEmpty()
            .WithMessage("email is required.")
            .EmailAddress()
            .WithMessage("invalid email format.")
            .MaximumLength(200)
            .WithMessage("email must not exceed 200 characters.");

        RuleFor(owner => owner.UserId)
            .NotEmpty()
            .WithMessage("userId is required.")
            .MaximumLength(200)
            .WithMessage("userId must not exceed 200 characters.")
            .Matches(@"^[a-zA-Z0-9\-_]+$")
            .WithMessage("userId contains invalid characters.");
    }
}
