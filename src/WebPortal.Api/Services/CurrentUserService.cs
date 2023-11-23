using Application.Common.Interfaces;

namespace WebPortal.Api.Services;

public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
    //public string UserId => (httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == "sub")!.Value ?? string.Empty)!;
    public string UserId => "8412";
}