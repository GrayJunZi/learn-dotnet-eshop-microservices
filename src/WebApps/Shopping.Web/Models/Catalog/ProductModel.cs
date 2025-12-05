namespace Shopping.Web.Models.Catalog;

public class ProductModel
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public List<string> Categories { get; set; } = new();
    public required string Description { get; set; }
    public required string ImageFile { get; set; }
    public decimal Price { get; set; }
}

public record GetProductsResponse(IEnumerable<ProductModel> Products);

public record GetProductByCategoryResponse(IEnumerable<ProductModel> Products);

public record GetProductByIdResponse(ProductModel Product);