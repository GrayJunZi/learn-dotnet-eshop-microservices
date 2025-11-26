namespace Ordering.Application.Extensions;

public static class OrderExtensions
{
    public static IEnumerable<OrderDto> ToOrderDtos(this IEnumerable<Order> orders)
    {
        return orders.Select(x => new OrderDto(
            Id: x.Id.Value,
            CustomerId: x.CustomerId.Value,
            OrderName: x.OrderName.Value,
            ShippingAddress: new AddressDto(
                x.ShippingAddress.Name,
                x.ShippingAddress.Email,
                x.ShippingAddress.AddressLine,
                x.ShippingAddress.Country,
                x.ShippingAddress.State,
                x.ShippingAddress.ZipCode
            ),
            BillingAddress: new AddressDto(
                x.BillingAddress.Name,
                x.BillingAddress.Email,
                x.BillingAddress.AddressLine,
                x.BillingAddress.Country,
                x.BillingAddress.State,
                x.BillingAddress.ZipCode
            ),
            Payment: new PaymentDto(
                x.Payment.CardName,
                x.Payment.CardNumber,
                x.Payment.Expiration,
                x.Payment.Cvv,
                x.Payment.PaymentMethod
            ),
            Status: x.Status,
            OrderItems: x.OrderItems.Select(y =>
                new OrderItemDto(y.OrderId.Value, y.ProductId.Value, y.Quantity, y.Price)
            ).ToList()
        ));
    }
}