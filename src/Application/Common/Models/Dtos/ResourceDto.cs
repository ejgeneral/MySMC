using Domain.Common.Types;
using Domain.Entities.ResourceAggregate;

namespace Application.Common.Models.Dtos;

public class ResourceDto
{
   public Guid Guid { get; init; }
   
   #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
   public string GivenNames { get; init; }
   
   public string? MiddleName { get; init; }
   
   public string FamilyName { get; init; }
   
   public Gender? Gender { get; init; }
   
   public DateOnly? Birthday { get; init; }
   
   public double Age { get; init; }
   
   public string Birthplace { get; init; }
   
   public CivilStatus? CivilStatus { get; init; }
   
   public string? Nationality { get; init; }
   
   public string? Religion { get; init; }

   // ReSharper disable once CollectionNeverUpdated.Global
   public List<AddressDto> AddressList { get; init; } 
  
   // ReSharper disable once CollectionNeverUpdated.Global
   public List<ParentInfoDto> ParentList { get; init; }
   
   private class Mapping : Profile
   {
      public Mapping()
      {
         CreateMap<Resource, ResourceDto>();
      }
   } 
}