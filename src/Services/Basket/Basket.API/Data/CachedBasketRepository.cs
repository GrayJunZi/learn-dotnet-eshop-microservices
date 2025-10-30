using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace Basket.API.Data;

public class CachedBasketRepository(
    IBasketRepository basketRepository,
    IDistributedCache distributedCache) : IBasketRepository
{
    public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default)
    {
        var cachedBasket = await distributedCache.GetStringAsync(userName, cancellationToken);
        if (!string.IsNullOrWhiteSpace(cachedBasket))
        {
            return JsonSerializer.Deserialize<ShoppingCart>(cachedBasket);
        }

        var basket = await basketRepository.GetBasket(userName, cancellationToken);
        await distributedCache.SetStringAsync(userName, JsonSerializer.Serialize(basket), cancellationToken);
        return basket;
    }

    public async Task<ShoppingCart> StoreBasket(ShoppingCart shoppingCart,
        CancellationToken cancellationToken = default)
    {
        var basket = await basketRepository.StoreBasket(shoppingCart, cancellationToken);

        await distributedCache.SetStringAsync(basket.UserName, JsonSerializer.Serialize(basket),
            cancellationToken);

        return basket;
    }

    public async Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default)
    {
        await basketRepository.DeleteBasket(userName, cancellationToken);
        await distributedCache.RemoveAsync(userName, cancellationToken);
        return true;
    }
}