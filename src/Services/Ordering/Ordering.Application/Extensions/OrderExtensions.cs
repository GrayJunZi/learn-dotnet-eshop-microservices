namespace Ordering.Application.Extensions;

public static class OrderExtensions
{
    public static OrderDto ToOrderDto(this Order order)
    {
        return new OrderDto(
            Id: order.Id.Value,
            CustomerId: order.CustomerId.Value,
            OrderName: order.OrderName.Value,
            ShippingAddress: new AddressDto(
                order.ShippingAddress.Name,
                order.ShippingAddress.Email,
                order.ShippingAddress.AddressLine,
                order.ShippingAddress.Country,
                order.ShippingAddress.State,
                order.ShippingAddress.ZipCode),
            BillingAddress: new AddressDto(
                order.BillingAddress.Name,
                order.BillingAddress.Email,
                order.BillingAddress.AddressLine,
                order.BillingAddress.Country,
                order.BillingAddress.State,
                order.BillingAddress.ZipCode),
            Payment: new PaymentDto(
                order.Payment.CardName,
                order.Payment.CardNumber,
                order.Payment.Expiration,
                order.Payment.Cvv,
                order.Payment.PaymentMethod),
            Status: order.Status,
            OrderItems: order.OrderItems.Select(y =>
                new OrderItemDto(y.OrderId.Value, y.ProductId.Value, y.Quantity, y.Price)
            ).ToList());
    }

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