namespace Vinder.Comanda.Domain.Errors;

public static class OwnerErrors
{
    public static readonly Error OwnerAlreadyExists = new(
        Code: "#COMANDA-ERROR-9DA90",
        Description: "A owner with the provided email already exists."
    );
}