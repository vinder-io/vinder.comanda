namespace Vinder.Comanda.Infrastructure.Repositories;

public sealed class CustomerRepository(IMongoDatabase database) :
    BaseRepository<Customer>(database, Collections.Customers),
    ICustomerRepository
{
    public async Task<IReadOnlyCollection<Customer>> GetCustomersAsync(
        CustomerFilters filters, CancellationToken cancellation = default)
    {
        var pipeline = PipelineDefinitionBuilder
            .For<Customer>()
            .As<Customer, Customer, BsonDocument>()
            .FilterCustomers(filters)
            .Paginate(filters);

        var options = new AggregateOptions { AllowDiskUse = true };
        var aggregation = await _collection.AggregateAsync(pipeline, options, cancellation);

        var bsonDocuments = await aggregation.ToListAsync(cancellation);
        var customers = bsonDocuments
            .Select(bson => BsonSerializer.Deserialize<Customer>(bson))
            .ToList();

        return customers;
    }

    public async Task<long> CountAsync(CustomerFilters filters, CancellationToken cancellation = default)
    {
        var pipeline = PipelineDefinitionBuilder
            .For<Customer>()
            .As<Customer, Customer, BsonDocument>()
            .FilterCustomers(filters)
            .Count();

        var aggregation = await _collection.AggregateAsync(pipeline, cancellationToken: cancellation);
        var result = await aggregation.FirstOrDefaultAsync(cancellation);

        return result?.Count ?? 0;
    }
}