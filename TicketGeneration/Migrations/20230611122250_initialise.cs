using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketGeneration.Migrations
{
    public partial class initialise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    ticketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ticketTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ticketDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ticketRaisedDate = table.Column<DateTime>(type: "date", nullable: false),
                    internId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.ticketId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
