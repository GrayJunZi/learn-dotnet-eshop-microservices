using Catalog.API.Exceptions;

namespace Catalog.API.Products.GetProductById;

public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;

public record GetProductByIdResult(Product Product);

internal class GetProductByIdHandler(
    IDocumentSession documentSession,
    ILogger<GetProductByIdHandler> logger)
    : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("{handler} called with {@Query}", nameof(GetProductByIdHandler), query);
        
        var product = await documentSession.LoadAsync<Product>(query.Id, cancellationToken);
        if (product == null)
            throw new ProductNotFoundException();
        
        return new GetProductByIdResult(product);
    }
}