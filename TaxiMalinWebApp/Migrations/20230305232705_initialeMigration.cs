using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxiMalinWebApp.Migrations
{
    public partial class initialeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "objetPerduMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroTelephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sujet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_objetPerduMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "reservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    NumeroTelephone = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    NbrePassager = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    AdresseDepart = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    AdresseDestination = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DateReservation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SelectTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AgreementIsChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "objetPerduMessages");

            migrationBuilder.DropTable(
                name: "reservations");
        }
    }
}
