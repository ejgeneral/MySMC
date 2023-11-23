using Application.Resources.Commands.CreateResource;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace WebPortal.Api.Controllers;


public class ResourceController : ApiControllerBase
{
    [HttpPost]
    public async Task<ErrorOr<(Guid, int)>> CreateResource(CreateResourceCommand command)
    {
        return await Mediator.Send(command);
    }
}