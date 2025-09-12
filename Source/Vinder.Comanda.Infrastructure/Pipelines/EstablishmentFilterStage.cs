namespace Vinder.Comanda.Infrastructure.Pipelines;

public static class EstablishmentFiltersStage
{
    public static PipelineDefinition<Establishment, BsonDocument> FilterEstablishments(
        this PipelineDefinition<Establishment, BsonDocument> pipeline,
        EstablishmentFilters filters)
    {
        var specifications = BuildMatchFilter(filters);
        return pipeline.Match(specifications);
    }

    private static FilterDefinition<BsonDocument> BuildMatchFilter(EstablishmentFilters filters)
    {
        var filterDefinitions = new List<FilterDefinition<BsonDocument>>
        {
            MatchIfNotEmpty(DocumentFields.Identifier, filters.Id),
            MatchIfNotEmpty(DocumentFields.Establishment.Name, filters.Name),
            MatchIfNotEmpty(DocumentFields.Establishment.OwnerId, filters.OwnerId),
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
}