namespace Vinder.Comanda.Infrastructure.Pipelines;

public static class CustomerFiltersStage
{
    public static PipelineDefinition<Customer, BsonDocument> FilterCustomers(
        this PipelineDefinition<Customer, BsonDocument> pipeline,
        CustomerFilters filters)
    {
        var specifications = BuildMatchFilter(filters);
        return pipeline.Match(specifications);
    }

    private static FilterDefinition<BsonDocument> BuildMatchFilter(CustomerFilters filters)
    {
        var filterDefinitions = new List<FilterDefinition<BsonDocument>>
        {
            MatchIfNotEmpty(DocumentFields.Identifier, filters.Id),
            MatchIfNotEmptyLike(DocumentFields.Customer.Name, filters.Name),
            MatchIfNotEmpty(DocumentFields.Customer.UserId, filters.UserId),
            MatchIfNotEmpty(DocumentFields.Customer.Email, filters.Email),
        };

        if (!filters.IsDeleted.HasValue)
        {
            filterDefinitions.Add(Builders<BsonDocument>.Filter.Eq(DocumentFields.IsDeleted, false));
        }
        else
        {
            filterDefinitions.Add(Builders<BsonDocument>.Filter.Eq(DocumentFields.IsDeleted, filters.IsDeleted.Value));
        }

        return Builders<BsonDocument>.Filter.And(filterDefinitions);
    }

    private static FilterDefinition<BsonDocument> MatchIfNotEmpty(string field, string? value)
    {
        return string.IsNullOrWhiteSpace(value)
            ? FilterDefinition<BsonDocument>.Empty
            : Builders<BsonDocument>.Filter.Eq(field, BsonValue.Create(value));
    }

    private static FilterDefinition<BsonDocument> MatchIfNotEmptyLike(string field, string? value)
    {
        return string.IsNullOrWhiteSpace(value)
            ? FilterDefinition<BsonDocument>.Empty
            : Builders<BsonDocument>.Filter.Regex(field, new BsonRegularExpression(value, "i"));
    }
}