using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartShop_Ab.Migrations
{
    public partial class initial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StockManagements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductNameId = table.Column<int>(type: "int", nullable: false),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StockCountId = table.Column<int>(type: "int", nullable: false),
                    MDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockManagements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockManagements_AddProducts_ProductNameId",
                        column: x => x.ProductNameId,
                        principalTable: "AddProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockManagements_AddProducts_StockCountId",
                        column: x => x.StockCountId,
                        principalTable: "AddProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StockManagements_ProductNameId",
                table: "StockManagements",
                column: "ProductNameId");

            migrationBuilder.CreateIndex(
                name: "IX_StockManagements_StockCountId",
                table: "StockManagements",
                column: "StockCountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockManagements");
        }
    }
}
