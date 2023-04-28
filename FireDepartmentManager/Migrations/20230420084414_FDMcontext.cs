using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FireDepartmentManager.Migrations
{
    public partial class FDMcontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Action",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Commander = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Driver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rescuers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vehicle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeOfAction = table.Column<int>(type: "int", nullable: false),
                    DateOfAlarm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfActionEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Action", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FireFighter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstAID = table.Column<bool>(type: "bit", nullable: false),
                    Commander = table.Column<bool>(type: "bit", nullable: false),
                    Driver = table.Column<bool>(type: "bit", nullable: false),
                    DateOfCourseCompletion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireFighter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeOfVehicle = table.Column<int>(type: "int", nullable: false),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false),
                    AutoPump = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Action");

            migrationBuilder.DropTable(
                name: "FireFighter");

            migrationBuilder.DropTable(
                name: "Vehicle");
        }
    }
}
