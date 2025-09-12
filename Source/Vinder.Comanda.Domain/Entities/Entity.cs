namespace Vinder.Comanda.Domain.Entities;

public abstract class Entity
{
    public string Id { get; private set; } = default!;
    public bool IsDeleted { get; private set; }

    public DateTime CreatedAt { get; private set; } = DateTime.Now;
    public DateTime UpdatedAt { get; private set; }

    public void SetIdentifier(string id) =>
        Id = id.Trim().Normalize(NormalizationForm.FormC);

    public void MarkAsDeleted() =>
        IsDeleted = true;

    public void MarkAsUpdated() =>
        UpdatedAt = DateTime.Now;
}
