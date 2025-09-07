namespace Vinder.Comanda.Domain.Entities;

public abstract class Entity
{
    public int Id { get; set; }
    public bool IsDeleted { get; private set; }

    public DateTime CreatedAt { get; private set; } = DateTime.Now;
    public DateTime UpdatedAt { get; private set; }

    public void MarkAsDeleted() =>
        IsDeleted = true;

    public void MarkAsUpdated() =>
        UpdatedAt = DateTime.Now;
}
