using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentNow.Infrastructure.Migrations
{
    public partial class schedulingtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SCHEDULING",
                columns: table => new
                {
                    KEY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CLIENTEKEY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TOTAL_HOURS = table.Column<int>(type: "int", nullable: true),
                    VEHICLEKEY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCHEDULING", x => x.KEY);
                    table.ForeignKey(
                        name: "FK_SCHEDULING_CLIENT_CLIENTEKEY",
                        column: x => x.CLIENTEKEY,
                        principalTable: "CLIENT",
                        principalColumn: "KEY",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SCHEDULING_VEHICLE_VEHICLEKEY",
                        column: x => x.VEHICLEKEY,
                        principalTable: "VEHICLE",
                        principalColumn: "KEY",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SCHEDULING_CLIENTEKEY",
                table: "SCHEDULING",
                column: "CLIENTEKEY");

            migrationBuilder.CreateIndex(
                name: "IX_SCHEDULING_VEHICLEKEY",
                table: "SCHEDULING",
                column: "VEHICLEKEY");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SCHEDULING");
        }
    }
}
