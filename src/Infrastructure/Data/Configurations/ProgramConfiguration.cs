using Domain.Common.Types;
using Domain.Entities.ProgramAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class ProgramConfiguration : IEntityTypeConfiguration<Program>
{
    public void Configure(EntityTypeBuilder<Program> builder)
    {
        ConfigureProgramTable(builder);
    }

    private void ConfigureProgramTable(EntityTypeBuilder<Program> builder)
    {
        builder.ToTable("Program");

        builder.HasKey(p => p.Id)
            .HasAnnotation("SqlServer:Clustered", false);
        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd();

        builder.HasAlternateKey(p => p.Code);
        builder.HasIndex(p => p.Code)
            .IsUnique()
            .IsClustered();
        builder.Property(p => p.Code)
            .HasColumnType("nvarchar(10)");

        builder.Property(p => p.Name)
            .HasColumnType("nvarchar(125)");

        builder.Property(p => p.Description)
            .HasColumnType("text");

        builder.Property(p => p.DeptCode)
            .HasColumnType("nvarchar(10)");

        builder.Property(p => p.Credential)
            .HasColumnType("nvarchar(15)")
            .HasConversion(value => value.Name,
                value => Credential.FromName(value, true));

        builder.Property(p => p.Catalog)
            .HasColumnType("nvarchar(15)");

    }
}