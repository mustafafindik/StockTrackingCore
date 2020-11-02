using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace StockTrackingCore.Api.Migrations
{
    public partial class SupplieradnCustomeradd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_VatRates_VatRateId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_VatRateId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VatRateId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseVatRateId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SalesVatRateId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CustomerName = table.Column<string>(maxLength: 200, nullable: false),
                    TaxId = table.Column<string>(nullable: true),
                    TaxOffice = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    SupplierName = table.Column<string>(maxLength: 200, nullable: false),
                    TaxId = table.Column<string>(nullable: true),
                    TaxOffice = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_PurchaseVatRateId",
                table: "Products",
                column: "PurchaseVatRateId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SalesVatRateId",
                table: "Products",
                column: "SalesVatRateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_VatRates_PurchaseVatRateId",
                table: "Products",
                column: "PurchaseVatRateId",
                principalTable: "VatRates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_VatRates_SalesVatRateId",
                table: "Products",
                column: "SalesVatRateId",
                principalTable: "VatRates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_VatRates_PurchaseVatRateId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_VatRates_SalesVatRateId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Products_PurchaseVatRateId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SalesVatRateId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PurchaseVatRateId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SalesVatRateId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "VatRateId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_VatRateId",
                table: "Products",
                column: "VatRateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_VatRates_VatRateId",
                table: "Products",
                column: "VatRateId",
                principalTable: "VatRates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
