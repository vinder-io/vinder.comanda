namespace Vinder.Comanda.Infrastructure.Utilities;

public static class FilterDefinitions
{
    public static FilterDefinition<BsonDocument> MatchIfNotEmpty(string field, string? value)
    {
        return string.IsNullOrWhiteSpace(value)
            ? FilterDefinition<BsonDocument>.Empty
            : Builders<BsonDocument>.Filter.Eq(field, BsonValue.Create(value));
    }

    public static FilterDefinition<BsonDocument> MatchIfNotEmptyContains(string field, string? value)
    {
        return string.IsNullOrWhiteSpace(value)
            ? FilterDefinition<BsonDocument>.Empty
            : Builders<BsonDocument>.Filter.Regex(field, new BsonRegularExpression(value, "i"));
    }

    public static FilterDefinition<BsonDocument> MatchBool(string field, bool? value, bool defaultValue = false)
    {
        return Builders<BsonDocument>.Filter.Eq(field, value ?? defaultValue);
    }

    public static FilterDefinition<BsonDocument> MatchIfNotEmptyEnum<TEnum>(string field, TEnum? value)
        where TEnum : struct, Enum
    {
        return value.HasValue
            ? Builders<BsonDocument>.Filter.Eq(field, Convert.ToInt32(value.Value))
            : FilterDefinition<BsonDocument>.Empty;
    }
}
