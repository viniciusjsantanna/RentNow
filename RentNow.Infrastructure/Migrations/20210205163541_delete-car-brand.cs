using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentNow.Infrastructure.Migrations
{
    public partial class deletecarbrand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VEHICLE_CAR_BRAND_CAR_BRAND_KEY",
                table: "VEHICLE");

            migrationBuilder.DropIndex(
                name: "IX_VEHICLE_CAR_BRAND_KEY",
                table: "VEHICLE");

            migrationBuilder.DropColumn(
                name: "CAR_BRAND_KEY",
                table: "VEHICLE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CAR_BRAND_KEY",
                table: "VEHICLE",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VEHICLE_CAR_BRAND_KEY",
                table: "VEHICLE",
                column: "CAR_BRAND_KEY");

            migrationBuilder.AddForeignKey(
                name: "FK_VEHICLE_CAR_BRAND_CAR_BRAND_KEY",
                table: "VEHICLE",
                column: "CAR_BRAND_KEY",
                principalTable: "CAR_BRAND",
                principalColumn: "KEY",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
