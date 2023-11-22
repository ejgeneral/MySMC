using Application.Common.Interfaces;
using MediatR;

namespace Application.Common.Behaviors;

public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull, IRequest<TResponse>
{
    private readonly ICurrentUserService _currentUserService;
    // private readonly IIdentityService _identityService;

    public AuthorizationBehavior(
        ICurrentUserService currentUserService)
    {
        _currentUserService = currentUserService;
        // _identityService = identityService;
    }

    /// <summary>
    /// In the original Clean Architecture code from Jayson Taylor he implemented an authorization handler in here
    /// that uses IIdentityService implementation. We won't be doing any authorization in here since we are passing
    /// JWT tokens that contain role and that's where we evaluate our policies.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="next"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        return await next();
    }

}