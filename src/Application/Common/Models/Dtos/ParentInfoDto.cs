using Domain.Common.Types;
using Domain.Entities.ResourceAggregate;

// ReSharper disable once IdentifierTypo
namespace Application.Common.Models.Dtos;

public class ParentInfoDto
{
   public Guid ResourceId { get; init; }
   
   #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
   public string GivenNames { get; init; }
   
   public string? MiddleName { get; init; }
   
   public string FamilyName { get; init; }
   
   public ParentType? ParentType { get; init; }
   
   public string? HomeTelephone { get; init; }
   
   public string? MobileTelephone { get; init; }
   
   public string? EmailAddress { get; init; }
   
   public string? Occupation { get; init; }
   
   public string? EmployerName { get; init; }
   
   public string? HighestEducationAttainment { get; init; }
   
   public string? SchoolAttended { get; init; }

   public bool IsDeceased { get; init; }
   
   private class Mapping : Profile
   {
      public Mapping()
      {
         CreateMap<ParentInfo, ParentInfoDto>();
      }
   } 
}