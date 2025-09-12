namespace Vinder.Comanda.Infrastructure.Repositories;

public sealed class EstablishmentRepository(IMongoDatabase database) :
    BaseRepository<Establishment>(database, Collections.Establishments),
    IEstablishmentRepository
{
    public async Task<IReadOnlyCollection<Establishment>> GetEstablishmentsAsync(
        EstablishmentFilters filters, CancellationToken cancellation = default)
    {
        var pipeline = PipelineDefinitionBuilder
            .For<Establishment>()
            .As<Establishment, Establishment, BsonDocument>()
            .FilterEstablishments(filters)
            .Paginate(filters);

        var options = new AggregateOptions { AllowDiskUse = true };
        var aggregation = await _collection.AggregateAsync(pipeline, options, cancellation);

        var bsonDocuments = await aggregation.ToListAsync(cancellation);
        var establishments = bsonDocuments
            .Select(bson => BsonSerializer.Deserialize<Establishment>(bson))
            .ToList();

        return establishments;
    }

    public async Task<long> CountAsync(EstablishmentFilters filters, CancellationToken cancellation = default)
    {
        var pipeline = PipelineDefinitionBuilder
            .For<Establishment>()
            .As<Establishment, Establishment, BsonDocument>()
            .FilterEstablishments(filters)
            .Count();

        var aggregation = await _collection.AggregateAsync(pipeline, cancellationToken: cancellation);
        var result = await aggregation.FirstOrDefaultAsync(cancellation);

        return result?.Count ?? 0;
    }
}