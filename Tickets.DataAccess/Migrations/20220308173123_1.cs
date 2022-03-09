using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tickets.DataAccess.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    tic_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tic_Usuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tic_FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tic_FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tic_Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.tic_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ticket");
        }
    }
}
