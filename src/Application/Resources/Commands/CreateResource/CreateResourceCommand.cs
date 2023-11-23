// ReSharper disable InconsistentNaming

using System.Net.NetworkInformation;
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Common.Models.Dtos;
using Domain.Common.Types;
using Domain.Entities.ResourceAggregate;

namespace Application.Resources.Commands.CreateResource;

public record CreateResourceCommand(
    
    string givenNames,
    string? middleName,
    string familyName,
    Gender? gender,
    DateOnly? birthday,
    string? birthplace,
    CivilStatus? civilStatus,
    string? nationality,
    string? religion,
    List<Address> addresses,
    List<ParentInfo> parentInfos) : IRequest<ErrorOr<(Guid, int)>>;

public class CreateResourceCommandHandler : BaseCommand, IRequestHandler<CreateResourceCommand, ErrorOr<(Guid, int)>>
{
    public CreateResourceCommandHandler(IAdminDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        : base(context, mapper, currentUserService)
    {
    }

    public async Task<ErrorOr<(Guid, int)>> Handle(CreateResourceCommand request, CancellationToken cancellationToken)
    {
        var resource = Resource.Create(
            request.givenNames,
            request.middleName,
            request.familyName,
            request.gender,
            request.birthday,
            request.birthplace,
            request.civilStatus,
            request.nationality,
            request.religion);
        
        if (request.addresses.Count != 0)
            request.addresses.ForEach(address => resource.AddAddress(address));

        if (request.parentInfos.Count != 0)
            request.parentInfos.ForEach(parent => resource.AddParent(parent));

        Context.Resources.Add(resource);
        await Context.SaveChangesAsync(cancellationToken);
        
        return (resource.Guid, resource.Id);
    }    
}    