namespace Catalog.API.Products.UpdateProduct;

public record UpdateProductRequest(
    Guid Id,
    string Name,
    List<string> Categories,
    string Description,
    string ImageFile,
    decimal Price);

public record UpdateProductResponse(bool IsSuccess);

public class UpdateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app
            .MapPut("/products", async (UpdateProductRequest request, ISender sender) =>
            {
                var result = await sender.Send(new UpdateProductCommand(
                    request.Id, request.Name, request.Categories, request.Description, request.ImageFile,
                    request.Price));

                var response = result.Adapt<UpdateProductResponse>();

                return Results.Ok(response);
            })
            .WithName("UpdateProduct")
            .WithDescription("Update Product")
            .WithSummary("Update Product")
            .Produces<UpdateProductResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest);
    }
}