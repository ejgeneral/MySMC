﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(AdminDbContext))]
    partial class AdminDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.ProgramAggregate.Program", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Catalog")
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Credential")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("DeptCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(125)");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"), false);

                    b.HasAlternateKey("Code");

                    b.HasIndex("Code")
                        .IsUnique();

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("Code"));

                    b.ToTable("Program", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.ResourceAggregate.Resource", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly?>("Birthday")
                        .HasColumnType("date");

                    b.Property<string>("Birthplace")
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("CivilStatus")
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FamilyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("GivenNames")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Religion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Guid");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Guid"), false);

                    b.HasAlternateKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasAlternateKey("Id"));

                    b.ToTable("Resource", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.ResourceAggregate.Resource", b =>
                {
                    b.OwnsMany("Domain.Entities.ResourceAggregate.Address", "AddressList", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<string>("Baranggay")
                                .HasColumnType("nvarchar(35)");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("nvarchar(35)");

                            b1.Property<DateTimeOffset>("Created")
                                .HasColumnType("datetimeoffset");

                            b1.Property<string>("CreatedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<bool>("IsPrimary")
                                .HasColumnType("bit");

                            b1.Property<DateTimeOffset>("LastModified")
                                .HasColumnType("datetimeoffset");

                            b1.Property<string>("LastModifiedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Line1")
                                .IsRequired()
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("Line2")
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("Municipality")
                                .IsRequired()
                                .HasColumnType("nvarchar(35)");

                            b1.Property<string>("PostalCode")
                                .HasColumnType("nvarchar(10)");

                            b1.Property<string>("Province")
                                .IsRequired()
                                .HasColumnType("nvarchar(35)");

                            b1.Property<Guid>("ResourceId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("Id");

                            b1.HasIndex("ResourceId");

                            b1.ToTable("Address", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ResourceId");
                        });

                    b.OwnsMany("Domain.Entities.ResourceAggregate.ParentInfo", "ParentList", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<DateTimeOffset>("Created")
                                .HasColumnType("datetimeoffset");

                            b1.Property<string>("CreatedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("EmailAddress")
                                .HasColumnType("nvarchar(100)");

                            b1.Property<string>("EmployerName")
                                .HasColumnType("nvarchar(100)");

                            b1.Property<string>("FamilyName")
                                .IsRequired()
                                .HasColumnType("nvarchar(35)");

                            b1.Property<string>("GivenNames")
                                .IsRequired()
                                .HasColumnType("nvarchar(35)");

                            b1.Property<string>("HighestEducationAttainment")
                                .HasColumnType("nvarchar(75)");

                            b1.Property<string>("HomeTelephone")
                                .HasColumnType("nvarchar(15)");

                            b1.Property<bool>("IsDeceased")
                                .HasColumnType("bit");

                            b1.Property<DateTimeOffset>("LastModified")
                                .HasColumnType("datetimeoffset");

                            b1.Property<string>("LastModifiedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("MiddleName")
                                .HasColumnType("nvarchar(35)");

                            b1.Property<string>("MobileTelephone")
                                .HasColumnType("nvarchar(15)");

                            b1.Property<string>("Occupation")
                                .HasColumnType("nvarchar(75)");

                            b1.Property<string>("ParentType")
                                .HasColumnType("nvarchar(15)");

                            b1.Property<Guid>("ResourceId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("SchoolAttended")
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("Id");

                            b1.HasIndex("ResourceId");

                            b1.ToTable("ParentInfo", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ResourceId");
                        });

                    b.Navigation("AddressList");

                    b.Navigation("ParentList");
                });
#pragma warning restore 612, 618
        }
    }
}
