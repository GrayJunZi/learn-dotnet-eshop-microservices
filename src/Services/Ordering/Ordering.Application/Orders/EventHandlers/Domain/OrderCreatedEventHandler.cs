using MassTransit;
using Microsoft.FeatureManagement;
using Ordering.Application.Extensions;

namespace Ordering.Application.Orders.EventHandlers.Domain;

public class OrderCreatedEventHandler(
    IPublishEndpoint publishEndpoint,
    IFeatureManager featureManager,
    ILogger<OrderCreatedEventHandler> logger)
    : INotificationHandler<OrderCreatedEvent>
{
    public async Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);

        if (!await featureManager.IsEnabledAsync("OrderFulfilment"))
        {
            return;
        }

        // 发布事件
        var orderCreatedIntegrationEvent = notification.Order.ToOrderDto();
        await publishEndpoint.Publish(orderCreatedIntegrationEvent, cancellationToken);
    }
}