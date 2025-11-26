namespace Ordering.Domain.ValueObjects;

public record CustomerId
{
    public Guid Value { get; }

    private CustomerId(Guid value) => Value = value;

    public static CustomerId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (Guid.Empty == value)
        {
            throw new DomainException("CustomerId cannot be empty.");
        }

        return new CustomerId(value);
    }
}