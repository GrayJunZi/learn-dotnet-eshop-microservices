namespace Ordering.Application.Dtos;

public record AddressDto(
    string Name,
    string Email,
    string AddressLine,
    string Country,
    string State,
    string ZipCode);