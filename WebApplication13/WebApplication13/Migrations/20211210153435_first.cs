using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication13.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    applicationTypeId = table.Column<string>(nullable: true),
                    prisonerId = table.Column<string>(nullable: true),
                    tutorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationType",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guard",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    surname = table.Column<string>(nullable: true),
                    brithdate = table.Column<string>(nullable: true),
                    acceptanceDate = table.Column<string>(nullable: true),
                    dissmisialDate = table.Column<string>(nullable: true),
                    prisonPositionId = table.Column<string>(nullable: true),
                    prisonRankId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guard", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guilt",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    prisonerId = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guilt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    external = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    locationId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    country = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    street = table.Column<string>(nullable: true),
                    propertyNumber = table.Column<int>(nullable: false),
                    apartamentNumber = table.Column<int>(nullable: false),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prisoner",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    surname = table.Column<string>(nullable: true),
                    brithdate = table.Column<string>(nullable: true),
                    entryDate = table.Column<string>(nullable: true),
                    leaveDate = table.Column<string>(nullable: true),
                    prisonLocationId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prisoner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrisonerJob",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    startDate = table.Column<string>(nullable: true),
                    endDate = table.Column<string>(nullable: true),
                    prisonerId = table.Column<string>(nullable: true),
                    jobId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrisonerJob", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrisonLocation",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    building = table.Column<string>(nullable: true),
                    floor = table.Column<string>(nullable: true),
                    room = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrisonLocation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrisonPosition",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrisonPosition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrisonRank",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrisonRank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    startTime = table.Column<string>(nullable: true),
                    endTime = table.Column<string>(nullable: true),
                    dayOfWeek = table.Column<string>(nullable: true),
                    quardId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sensor",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    prisonLocationId = table.Column<string>(nullable: true),
                    sensorTypeId = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SensorLog",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    sensorId = table.Column<string>(nullable: true),
                    date = table.Column<string>(nullable: true),
                    content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SensorType",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorType", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Application");

            migrationBuilder.DropTable(
                name: "ApplicationType");

            migrationBuilder.DropTable(
                name: "Guard");

            migrationBuilder.DropTable(
                name: "Guilt");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Prisoner");

            migrationBuilder.DropTable(
                name: "PrisonerJob");

            migrationBuilder.DropTable(
                name: "PrisonLocation");

            migrationBuilder.DropTable(
                name: "PrisonPosition");

            migrationBuilder.DropTable(
                name: "PrisonRank");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "Sensor");

            migrationBuilder.DropTable(
                name: "SensorLog");

            migrationBuilder.DropTable(
                name: "SensorType");
        }
    }
}
