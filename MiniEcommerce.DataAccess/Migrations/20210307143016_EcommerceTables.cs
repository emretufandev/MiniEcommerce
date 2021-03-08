using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniEcommerce.DataAccess.Migrations
{
    public partial class EcommerceTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    UpdatedTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Barcode = table.Column<string>(maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    Stock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    UpdatedTime = table.Column<DateTime>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    Url = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Barcode", "CreatedTime", "Description", "Name", "Price", "Stock", "UpdatedTime" },
                values: new object[] { 1, "HBV000017C1M6", new DateTime(2021, 3, 7, 17, 30, 15, 931, DateTimeKind.Local).AddTicks(6814), "Samsung Galaxy ailesinin yeni üyelerinden biri olan Samsung Galaxy S21 Ultra 5G 256 GB, özellikleriyle cezbediyor.", "Samsung Galaxy S21 Ultra 5G 256 GB", 14999m, 50, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Barcode", "CreatedTime", "Description", "Name", "Price", "Stock", "UpdatedTime" },
                values: new object[] { 2, "HBV0000120X68", new DateTime(2021, 3, 7, 17, 30, 15, 932, DateTimeKind.Local).AddTicks(8290), "Yeni çift kamera sistemi. Tüm gün süren pil ömrü1. Bir akıllı telefondaki en dayanıklı cam. Ve Apple’ın bugüne kadarki en hızlı çipi.", "iPhone 11 64 GB", 7500m, 60, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Barcode", "CreatedTime", "Description", "Name", "Price", "Stock", "UpdatedTime" },
                values: new object[] { 3, "HBV00000TOMR2", new DateTime(2021, 3, 7, 17, 30, 15, 932, DateTimeKind.Local).AddTicks(8332), "10 (Q) versiyon Android işletim sistemiyle gelen telefonlar, kullanıcı dostu MIUI 11 arayüzü ile kolay kullanım konforuna sahiptir.", "Xiaomi Redmi Note 9 Pro 128 GB", 3399m, 60, null });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "CreatedTime", "ProductId", "UpdatedTime", "Url" },
                values: new object[] { 1, new DateTime(2021, 3, 7, 17, 30, 15, 934, DateTimeKind.Local).AddTicks(6898), 1, null, "~/images/iphone.jpg" });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "CreatedTime", "ProductId", "UpdatedTime", "Url" },
                values: new object[] { 2, new DateTime(2021, 3, 7, 17, 30, 15, 934, DateTimeKind.Local).AddTicks(6953), 2, null, "~/images/samsung.jpg" });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "CreatedTime", "ProductId", "UpdatedTime", "Url" },
                values: new object[] { 3, new DateTime(2021, 3, 7, 17, 30, 15, 934, DateTimeKind.Local).AddTicks(6956), 3, null, "~/images/xiaomi.jpg" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
