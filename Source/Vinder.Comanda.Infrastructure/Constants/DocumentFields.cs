namespace Vinder.Comanda.Infrastructure.Constants;

public static class DocumentFields
{
    public const string Identifier = "_id";
    public const string CreatedAt = nameof(Entity.CreatedAt);
    public const string UpdatedAt = nameof(Entity.UpdatedAt);
    public const string IsDeleted = nameof(Entity.IsDeleted);

    public static class Establishment
    {
        public const string Name = "Name";
        public const string Description = "Description";
        public const string OwnerId = "Owner._id";
        public const string SubscriptionId = "Subscription._id";
    }
}