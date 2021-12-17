using Microsoft.EntityFrameworkCore.Migrations;

namespace Russian_Robotics.Migrations
{
    public partial class SCV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PriceItems",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vendor = table.Column<string>(type: "varchar(64)", nullable: true),
                    Number = table.Column<string>(type: "varchar(64)", nullable: true),
                    SearchVendor = table.Column<string>(type: "varchar(64)", nullable: true),
                    SearchNumber = table.Column<string>(type: "varchar(64)", nullable: true),
                    Description = table.Column<string>(type: "varchar(512)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceItems", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PriceItems");
        }
    }
}
