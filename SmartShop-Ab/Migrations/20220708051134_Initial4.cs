using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartShop_Ab.Migrations
{
    public partial class Initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockCount = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddProducts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddProducts");
        }
    }
}
