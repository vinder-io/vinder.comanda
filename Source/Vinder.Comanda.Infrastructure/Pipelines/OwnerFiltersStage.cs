namespace Vinder.Comanda.Infrastructure.Pipelines;

public static class OwnerFiltersStage
{
    public static PipelineDefinition<Owner, BsonDocument> FilterOwners(
        this PipelineDefinition<Owner, BsonDocument> pipeline, OwnerFilters filters)
    {
        var definitions = new List<FilterDefinition<BsonDocument>>
        {
            FilterDefinitions.MatchIfNotEmpty(DocumentFields.Owner.Id, filters.Id),
            FilterDefinitions.MatchIfNotEmpty(DocumentFields.Owner.UserId, filters.UserId),
            FilterDefinitions.MatchIfNotEmpty(DocumentFields.Owner.Email, filters.Email),

            FilterDefinitions.MatchIfNotEmptyContains(DocumentFields.Owner.Name, filters.Name),
            FilterDefinitions.MatchIfNotEmptyEnum(DocumentFields.Owner.Subscription, filters.SubscriptionStatus),
            FilterDefinitions.MatchBool(DocumentFields.Owner.IsDeleted, filters.IsDeleted)
        };

        return pipeline.Match(Builders<BsonDocument>.Filter.And(definitions));
    }
}