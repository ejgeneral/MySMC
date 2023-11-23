using Application.Common.Interfaces;

namespace Application.Common.Models;

public abstract class BaseCommand
{
    protected IAdminDbContext Context;
    protected IMapper Mapper;
    protected ICurrentUserService CurrentUserService;
    
    protected BaseCommand(IAdminDbContext context, IMapper mapper, ICurrentUserService currentUserService)
    {
        Context = context;
        Mapper = mapper;
        CurrentUserService = currentUserService;
    }
}