using Application.Common.Interfaces;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Application.Common.Behaviors;

public class LoggingBehavior<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
{
    private readonly ILogger _logger;
    private readonly ICurrentUserService _currentUserService;

    public LoggingBehavior(ILogger<TRequest> logger, ICurrentUserService currentUserService)
    {
        _logger = logger;
        _currentUserService = currentUserService;
    }

    /// <summary>
    /// In the original Clean Architecture code from Jayson Taylor he implemented an authorization handler in here
    /// that uses IIdentityService implementation. We won't be doing any authorization in here since we are passing
    /// JWT tokens that contain role and that's where we evaluate our policies.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    public Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var userId = _currentUserService.UserId ?? string.Empty;


        _logger.LogInformation("Request: {Name} {@UserId} {@Request}",
            requestName, userId, request);
        return Task.CompletedTask;
    }
}