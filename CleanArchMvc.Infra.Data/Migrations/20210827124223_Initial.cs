using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchMvc.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Categories",
                table => new
                {
                    Id = table.Column<int>("int")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>("nvarchar(100)", maxLength: 100)
                },
                constraints: table => { table.PrimaryKey("PK_Categories", x => x.Id); });

            migrationBuilder.CreateTable(
                "Products",
                table => new
                {
                    Id = table.Column<int>("int")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>("nvarchar(100)", maxLength: 100),
                    Description = table.Column<string>("nvarchar(200)", maxLength: 200),
                    Price = table.Column<decimal>("decimal(10,2)", precision: 10, scale: 2),
                    Stock = table.Column<int>("int"),
                    Image = table.Column<string>("nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>("int")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        "FK_Products_Categories_CategoryId",
                        x => x.CategoryId,
                        "Categories",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                "Categories",
                new[] {"Id", "Name"},
                new object[] {1, "Material Escolar"});

            migrationBuilder.InsertData(
                "Categories",
                new[] {"Id", "Name"},
                new object[] {2, "Eletrônicos"});

            migrationBuilder.InsertData(
                "Categories",
                new[] {"Id", "Name"},
                new object[] {3, "Acessórios"});

            migrationBuilder.CreateIndex(
                "IX_Products_CategoryId",
                "Products",
                "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Products");

            migrationBuilder.DropTable(
                "Categories");
        }
    }
}