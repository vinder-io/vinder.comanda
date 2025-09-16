namespace Vinder.Comanda.Domain.Errors;

public static class CustomerErrors
{
    public static readonly Error CustomerAlreadyExists = new(
        Code: "#COMANDA-ERROR-76A714",
        Description: "A customer with the provided email already exists."
    );
}