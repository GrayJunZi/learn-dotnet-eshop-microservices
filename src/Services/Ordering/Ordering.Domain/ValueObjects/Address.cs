namespace Ordering.Domain.ValueObjects;

public record Address
{
    public string Name { get; }
    public string Email { get; }
    public string AddressLine { get; }
    public string Country { get; }
    public string State { get; }
    public string ZipCode { get; }

    protected Address()
    {
    }

    private Address(string name, string email, string addressLine, string country, string state, string zipCode)
    {
        Name = name;
        Email = email;
        AddressLine = addressLine;
        Country = country;
        State = state;
        ZipCode = zipCode;
    }

    public static Address Of(string name, string email, string addressLine, string country, string state,
        string zipcode)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(email);
        
        return new Address(name, email, addressLine, country, state, zipcode);
    }
}