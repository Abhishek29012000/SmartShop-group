using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartShop_Ab.Migrations
{
    public partial class initial9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockManagements_AddProducts_ProductNameId",
                table: "StockManagements");

            migrationBuilder.DropForeignKey(
                name: "FK_StockManagements_AddProducts_StockCountId",
                table: "StockManagements");

            migrationBuilder.DropIndex(
                name: "IX_StockManagements_ProductNameId",
                table: "StockManagements");

            migrationBuilder.DropIndex(
                name: "IX_StockManagements_StockCountId",
                table: "StockManagements");

            migrationBuilder.DropColumn(
                name: "ProductNameId",
                table: "StockManagements");

            migrationBuilder.DropColumn(
                name: "StockCountId",
                table: "StockManagements");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "StockManagements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "StockCount",
                table: "StockManagements",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "StockManagements");

            migrationBuilder.DropColumn(
                name: "StockCount",
                table: "StockManagements");

            migrationBuilder.AddColumn<int>(
                name: "ProductNameId",
                table: "StockManagements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StockCountId",
                table: "StockManagements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StockManagements_ProductNameId",
                table: "StockManagements",
                column: "ProductNameId");

            migrationBuilder.CreateIndex(
                name: "IX_StockManagements_StockCountId",
                table: "StockManagements",
                column: "StockCountId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockManagements_AddProducts_ProductNameId",
                table: "StockManagements",
                column: "ProductNameId",
                principalTable: "AddProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockManagements_AddProducts_StockCountId",
                table: "StockManagements",
                column: "StockCountId",
                principalTable: "AddProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
