using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations.SqlServerMigrations
{
    public partial class createRetailTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmaailAddress",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Households",
                columns: table => new
                {
                    Hshd_Num = table.Column<int>(nullable: false),
                    Loyality_flag = table.Column<string>(nullable: true),
                    Age_range = table.Column<string>(nullable: true),
                    Marital_status = table.Column<string>(nullable: true),
                    Income_range = table.Column<string>(nullable: true),
                    Homeowner_desc = table.Column<string>(nullable: true),
                    Hshd_composition = table.Column<string>(nullable: true),
                    Hshd_size = table.Column<string>(nullable: true),
                    Children = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Households", x => x.Hshd_Num);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Product_num = table.Column<int>(nullable: false),
                    Department = table.Column<string>(nullable: true),
                    Comodity = table.Column<string>(nullable: true),
                    Brand_ty = table.Column<string>(nullable: true),
                    Natural_organic_flag = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Product_num);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Basket_num = table.Column<int>(nullable: false),
                    Hshd_Num = table.Column<int>(nullable: false),
                    Purchase = table.Column<string>(nullable: true),
                    Product_num = table.Column<int>(nullable: false),
                    Spend = table.Column<string>(nullable: true),
                    Units = table.Column<string>(nullable: true),
                    Stock_r = table.Column<string>(nullable: true),
                    Week_num = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Households_Hshd_Num",
                        column: x => x.Hshd_Num,
                        principalTable: "Households",
                        principalColumn: "Hshd_Num",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Products_Product_num",
                        column: x => x.Product_num,
                        principalTable: "Products",
                        principalColumn: "Product_num",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_Hshd_Num",
                table: "Transactions",
                column: "Hshd_Num");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_Product_num",
                table: "Transactions",
                column: "Product_num");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Households");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropColumn(
                name: "EmaailAddress",
                table: "Users");
        }
    }
}
