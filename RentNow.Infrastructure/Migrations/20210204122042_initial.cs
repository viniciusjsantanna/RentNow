using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentNow.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CAR_BRAND",
                columns: table => new
                {
                    KEY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAR_BRAND", x => x.KEY);
                });

            migrationBuilder.CreateTable(
                name: "CREDENTIALS",
                columns: table => new
                {
                    KEY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LOGIN = table.Column<string>(type: "varchar(20)", nullable: true),
                    PASSWORD = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CREDENTIALS", x => x.KEY);
                });

            migrationBuilder.CreateTable(
                name: "CAR_MODEL",
                columns: table => new
                {
                    KEY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "varchar(100)", nullable: true),
                    CAR_BRAND_KEY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAR_MODEL", x => x.KEY);
                    table.ForeignKey(
                        name: "FK_CAR_MODEL_CAR_BRAND_CAR_BRAND_KEY",
                        column: x => x.CAR_BRAND_KEY,
                        principalTable: "CAR_BRAND",
                        principalColumn: "KEY",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CLIENT",
                columns: table => new
                {
                    KEY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CPF = table.Column<string>(type: "varchar(11)", nullable: true),
                    BIRTHDATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NAME = table.Column<string>(type: "varchar(100)", nullable: true),
                    ROLE = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENT", x => x.KEY);
                    table.ForeignKey(
                        name: "FK_CLIENT_CREDENTIALS_KEY",
                        column: x => x.KEY,
                        principalTable: "CREDENTIALS",
                        principalColumn: "KEY",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OPERATOR",
                columns: table => new
                {
                    KEY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    REGISTRATION = table.Column<string>(type: "varchar(6)", nullable: true),
                    NAME = table.Column<string>(type: "varchar(100)", nullable: true),
                    ROLE = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPERATOR", x => x.KEY);
                    table.ForeignKey(
                        name: "FK_OPERATOR_CREDENTIALS_KEY",
                        column: x => x.KEY,
                        principalTable: "CREDENTIALS",
                        principalColumn: "KEY",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VEHICLE",
                columns: table => new
                {
                    KEY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PLATE = table.Column<string>(type: "varchar(8)", nullable: true),
                    CAR_BRAND_KEY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CAR_MODEL_KEY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    YEAR = table.Column<int>(type: "int", nullable: true),
                    HOUR_PRICE = table.Column<decimal>(type: "money", nullable: true),
                    FUEL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TRUNK_LIMIT = table.Column<string>(type: "varchar(50)", nullable: true),
                    CATEGORY = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VEHICLE", x => x.KEY);
                    table.ForeignKey(
                        name: "FK_VEHICLE_CAR_BRAND_CAR_BRAND_KEY",
                        column: x => x.CAR_BRAND_KEY,
                        principalTable: "CAR_BRAND",
                        principalColumn: "KEY",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VEHICLE_CAR_MODEL_CAR_MODEL_KEY",
                        column: x => x.CAR_MODEL_KEY,
                        principalTable: "CAR_MODEL",
                        principalColumn: "KEY",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ADDRESS",
                columns: table => new
                {
                    STREET = table.Column<string>(type: "varchar(200)", nullable: false),
                    POSTCODE = table.Column<string>(type: "varchar(10)", nullable: false),
                    NUMBER = table.Column<string>(type: "varchar(50)", nullable: false),
                    CITY = table.Column<string>(type: "varchar(100)", nullable: false),
                    STATE = table.Column<string>(type: "varchar(20)", nullable: false),
                    ClientKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    COMPLEMENT = table.Column<string>(type: "varchar(300)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADDRESS", x => new { x.STREET, x.POSTCODE, x.NUMBER, x.CITY, x.STATE, x.ClientKey });
                    table.ForeignKey(
                        name: "FK_ADDRESS_CLIENT_ClientKey",
                        column: x => x.ClientKey,
                        principalTable: "CLIENT",
                        principalColumn: "KEY",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ADDRESS_ClientKey",
                table: "ADDRESS",
                column: "ClientKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CAR_MODEL_CAR_BRAND_KEY",
                table: "CAR_MODEL",
                column: "CAR_BRAND_KEY");

            migrationBuilder.CreateIndex(
                name: "IX_VEHICLE_CAR_BRAND_KEY",
                table: "VEHICLE",
                column: "CAR_BRAND_KEY");

            migrationBuilder.CreateIndex(
                name: "IX_VEHICLE_CAR_MODEL_KEY",
                table: "VEHICLE",
                column: "CAR_MODEL_KEY");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ADDRESS");

            migrationBuilder.DropTable(
                name: "OPERATOR");

            migrationBuilder.DropTable(
                name: "VEHICLE");

            migrationBuilder.DropTable(
                name: "CLIENT");

            migrationBuilder.DropTable(
                name: "CAR_MODEL");

            migrationBuilder.DropTable(
                name: "CREDENTIALS");

            migrationBuilder.DropTable(
                name: "CAR_BRAND");
        }
    }
}
