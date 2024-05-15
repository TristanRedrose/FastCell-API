using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastCell_DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CellPhones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Manufacturer = table.Column<string>(type: "text", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CellPhones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RepairServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ServiceName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServicePrices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    PhoneId = table.Column<Guid>(type: "uuid", nullable: false),
                    CellPhoneId = table.Column<Guid>(type: "uuid", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uuid", nullable: false),
                    RepairServiceId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicePrices_CellPhones_CellPhoneId",
                        column: x => x.CellPhoneId,
                        principalTable: "CellPhones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicePrices_RepairServices_RepairServiceId",
                        column: x => x.RepairServiceId,
                        principalTable: "RepairServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServicePrices_CellPhoneId",
                table: "ServicePrices",
                column: "CellPhoneId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePrices_RepairServiceId",
                table: "ServicePrices",
                column: "RepairServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServicePrices");

            migrationBuilder.DropTable(
                name: "CellPhones");

            migrationBuilder.DropTable(
                name: "RepairServices");
        }
    }
}
