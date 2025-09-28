namespace Vinder.Comanda.Infrastructure.Pipelines;

public static class CustomerFiltersStage
{
    public static PipelineDefinition<Customer, BsonDocument> FilterCustomers(
        this PipelineDefinition<Customer, BsonDocument> pipeline, CustomerFilters filters)
    {
        var definitions = new List<FilterDefinition<BsonDocument>>
        {
            FilterDefinitions.MatchIfNotEmpty(DocumentFields.Customer.Id, filters.Id),
            FilterDefinitions.MatchIfNotEmpty(DocumentFields.Customer.UserId, filters.UserId),
            FilterDefinitions.MatchIfNotEmpty(DocumentFields.Customer.Email, filters.Email),

            // filters documents where customer.name contains the provided value (case-insensitive).
            // if filters.Name is null or empty, this filter is not applied.
            FilterDefinitions.MatchIfNotEmptyContains(DocumentFields.Customer.Name, filters.Name),
            FilterDefinitions.MatchBool(DocumentFields.Customer.IsDeleted, filters.IsDeleted)
        };

        return pipeline.Match(Builders<BsonDocument>.Filter.And(definitions));
    }
}