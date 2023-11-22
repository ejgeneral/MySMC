using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GivenNames = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    FamilyName = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: true),
                    Birthplace = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    CivilStatus = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.Guid)
                        .Annotation("SqlServer:Clustered", false);
                    table.UniqueConstraint("AK_Resource_Id", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Line1 = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Line2 = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Baranggay = table.Column<string>(type: "nvarchar(35)", nullable: true),
                    Municipality = table.Column<string>(type: "nvarchar(35)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(35)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(35)", nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => new { x.ResourceId, x.Id });
                    table.ForeignKey(
                        name: "FK_Address_Resource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resource",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParentInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GivenNames = table.Column<string>(type: "nvarchar(35)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(35)", nullable: true),
                    FamilyName = table.Column<string>(type: "nvarchar(35)", nullable: false),
                    ParentType = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    HomeTelephone = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    MobileTelephone = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Occupation = table.Column<string>(type: "nvarchar(75)", nullable: true),
                    EmployerName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    HighestEducationAttainment = table.Column<string>(type: "nvarchar(75)", nullable: true),
                    SchoolAttended = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    IsDeceased = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentInfo", x => new { x.ResourceId, x.Id });
                    table.ForeignKey(
                        name: "FK_ParentInfo_Resource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resource",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "ParentInfo");

            migrationBuilder.DropTable(
                name: "Resource");
        }
    }
}
