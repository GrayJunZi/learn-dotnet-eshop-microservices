namespace Ordering.Domain.Abstractions;

public abstract class Entity<TId> : IEntity<TId>
{
    public TId Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public string? ModifiedBy { get; set; }
}

