using Domain.Common.Types;
using Domain.Entities.ResourceAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            ConfigureResourceTable(builder);
            ConfigureAddressTable(builder);
            ConfigureParentInfoTable(builder);
        }

        private void ConfigureResourceTable(EntityTypeBuilder<Resource> builder)
        {
            builder.ToTable("Resource");
            builder.Ignore(p => p.Age);
            
            builder.HasKey(x => x.Guid)
                .HasAnnotation("SqlServer:Clustered", false);

            builder.HasAlternateKey(p => p.Id)
                .IsClustered(true);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.GivenNames)
                .HasColumnType("nvarchar(25)");

            builder.Property(p => p.MiddleName)
                .HasColumnType("nvarchar(25)");

            builder.Property(p => p.FamilyName)
                .HasColumnType("nvarchar(25)");

            builder.Property(p => p.Gender)
                .HasColumnType("nvarchar(10)")
                .HasConversion(value => value.Name,
                    value => Gender.FromName(value, true));

            builder.Property(p => p.Birthplace)
                .HasColumnType("nvarchar(25)");

            builder.Property(p => p.CivilStatus)
                .HasColumnType("nvarchar(10)")
                .HasConversion(value => value.Name,
                    value => CivilStatus.FromName(value, true));

            builder.Property(p => p.Nationality)
                .HasColumnType("nvarchar(25)");

        }

        private void ConfigureAddressTable(EntityTypeBuilder<Resource> builder)
        {
            builder.OwnsMany(p => p.AddressList, b => {
                b.ToTable("Address");

                b.HasKey(p => p.Id);
                
                b.WithOwner()
                    .HasForeignKey(p => p.ResourceId)
                    .HasPrincipalKey(p => p.Guid);

                b.Property(p => p.Line1)
                    .HasColumnType("nvarchar(50)");

                b.Property(p => p.Line2)
                    .HasColumnType("nvarchar(50)");

                b.Property(p => p.Baranggay)
                    .HasColumnType("nvarchar(35)");

                b.Property(p => p.Municipality)
                    .HasColumnType("nvarchar(35)");

                b.Property(p => p.Province)
                    .HasColumnType("nvarchar(35)");

                b.Property(p => p.PostalCode)
                    .HasColumnType("nvarchar(10)");

                b.Property(p => p.Country)
                    .HasColumnType("nvarchar(35)");

            });
        }

        private void ConfigureParentInfoTable(EntityTypeBuilder<Resource> builder)
        {
            builder.OwnsMany(p => p.ParentList, b =>
            {
                b.ToTable("ParentInfo");

                b.HasKey(p => p.Id);
                
                b.WithOwner()
                    .HasForeignKey(p => p.ResourceId)
                    .HasPrincipalKey(p => p.Guid);

                b.Property(p => p.GivenNames)
                    .HasColumnType("nvarchar(35)");

                b.Property(p => p.MiddleName)
                    .HasColumnType("nvarchar(35)");

                b.Property(p => p.FamilyName)
                    .HasColumnType("nvarchar(35)");

                b.Property(p => p.ParentType)
                    .HasColumnType("nvarchar(15)")
                    .HasConversion(value => value.Name,
                        value => ParentType.FromName(value, true));

                b.Property(p => p.HomeTelephone)
                    .HasColumnType("nvarchar(15)");

                b.Property(p => p.MobileTelephone)
                    .HasColumnType("nvarchar(15)");

                b.Property(p => p.EmailAddress)
                    .HasColumnType("nvarchar(100)");

                b.Property(p => p.Occupation)
                    .HasColumnType("nvarchar(75)");

                b.Property(p => p.EmployerName)
                    .HasColumnType("nvarchar(100)");

                b.Property(p => p.HighestEducationAttainment)
                    .HasColumnType("nvarchar(75)");

                b.Property(p => p.SchoolAttended)
                    .HasColumnType("nvarchar(100)");

            });
        }
    }
}
