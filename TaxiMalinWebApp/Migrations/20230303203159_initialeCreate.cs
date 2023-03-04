using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxiMalinWebApp.Migrations
{
    public partial class initialeCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "reservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroTelephone = table.Column<int>(type: "int", nullable: true),
                    NbrePassager = table.Column<int>(type: "int", nullable: true),
                    AdresseDepart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdresseDestination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateReservation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SelectTime = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reservations");
        }
    }
}
