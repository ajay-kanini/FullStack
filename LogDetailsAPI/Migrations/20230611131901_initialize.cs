using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogDetailsAPI.Migrations
{
    public partial class initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogDetails",
                columns: table => new
                {
                    logId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    logInTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    logOutTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    internID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogDetails", x => x.logId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogDetails");
        }
    }
}
