using MediatR;
using Microsoft.Extensions.Logging;

public class LoggingBehavior<TRequest, TResponse>
: IPipelineBehavior<TRequest, TResponse>
    where TRequest:IBaseRequest
{
    private readonly ILogger<TRequest> _logger;

    public LoggingBehavior(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken
        )
    {
        var name = request.GetType().Name;

        try
        {
            var initTime = DateTime.UtcNow;
            _logger.LogInformation($"Ejecutando Request: {name}");
            var result = await next();
            var timeExecution = DateTime.UtcNow - initTime;
            _logger.LogInformation($"Request {name} se ejecuto en: {timeExecution.Milliseconds}");

            return result;
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, $"Request {name} tuvo errores");
            throw;
        }

    }
}
