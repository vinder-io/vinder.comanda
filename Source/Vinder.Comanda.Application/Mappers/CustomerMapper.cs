namespace Vinder.Comanda.Application.Mappers;

public static class CustomerMapper
{
    public static Customer AsCustomer(CreateCustomerRequest request)
    {
        Customer customer = new();
        Identity identity = new(request.UserId, request.Email);

        customer.SetIdentity(identity);
        customer.SetName(request.Name);

        return customer;
    }

    public static CustomerDetails AsResponse(Customer customer) => new()
    {
        Id = customer.Id,
        Name = customer.Name,
        Email = customer.Identity.Email
    };
}