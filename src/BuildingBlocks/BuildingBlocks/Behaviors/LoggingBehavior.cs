using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BuildingBlocks.Behaviors;

public class LoggingBehavior<TRequet, TResponse>(ILogger<LoggingBehavior<TRequet, TResponse>> logger)
    : IPipelineBehavior<TRequet, TResponse>
    where TRequet : notnull, IRequest<TResponse>
    where TResponse : notnull
{
    public async Task<TResponse> Handle(TRequet request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("[START] Handle Request={Request} - Response={Response} - RequestData={RequestData}",
            typeof(TRequet).Name, typeof(TResponse).Name, request);

        var timer = Stopwatch.StartNew();

        var response = await next(cancellationToken);

        timer.Stop();
        var duration = timer.Elapsed;
        if (duration.Seconds > 3)
        {
            logger.LogWarning("[PERFORMANCE] The Request {Request} took {Duration} seconds.",
                typeof(TRequet).Name, duration.Seconds);
        }

        logger.LogInformation("[END] Handle {Request} with {Response}",
            typeof(TRequet).Name, typeof(TResponse).Name);
        return response;
    }
}