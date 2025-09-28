namespace Vinder.Comanda.Infrastructure.Pipelines;

public static class EstablishmentFiltersStage
{
    public static PipelineDefinition<Establishment, BsonDocument> FilterEstablishments(
        this PipelineDefinition<Establishment, BsonDocument> pipeline,
        EstablishmentFilters filters)
    {
        var definitions = new List<FilterDefinition<BsonDocument>>
        {
            FilterDefinitions.MatchIfNotEmpty(DocumentFields.Establishment.Id, filters.Id),
            FilterDefinitions.MatchIfNotEmptyContains(DocumentFields.Establishment.Name, filters.Name),
            FilterDefinitions.MatchIfNotEmpty(DocumentFields.Establishment.OwnerId, filters.OwnerId),
            FilterDefinitions.MatchBool(DocumentFields.Establishment.IsDeleted, filters.IsDeleted)
        };

        return pipeline.Match(Builders<BsonDocument>.Filter.And(definitions));
    }
}
