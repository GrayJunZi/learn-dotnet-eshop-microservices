namespace Shopping.Web.Models.Basket;

public class BasketCheckoutModel
{
    public string UserName { get; set; }
    public Guid CustomerId { get; set; }
    public decimal TotalPrice { get; set; }
    
    // Shipping & Billing Address
    public string Name { get; set; }
    public string Email { get; set; }
    public string AddressLine { get; set; }
    public string Country { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }

    // Payment
    public string CardName { get; set; }
    public string CardNumber { get; set; }
    public string Expiration { get; set; }
    public string Cvv { get; set; }
    public int PaymentMethod { get; set; }
}

public record CheckoutBasketRequest(BasketCheckoutModel BasketCheckout);

public record CheckoutBasketResponse(bool IsSuccess);