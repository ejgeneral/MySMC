using Domain.Entities.ResourceAggregate;

// ReSharper disable once IdentifierTypo
namespace Application.Common.Models.Dtos;

public class AddressDto
{
    public Guid ResourceId { get; init; }
    
    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public string Line1 { get; init; }
    
    public string? Line2 { get; init; }
    
    // ReSharper disable once IdentifierTypo
    public string? Baranggay { get; init; }
    
    public string Municipality { get; init; }
    
    public string Province { get; init; }
    
    public string? PostalCode { get; init; }
    
    public string Country { get; init; }
    
    public bool IsPrimary { get; init; }
    
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Address, AddressDto>();
        }
    }
}