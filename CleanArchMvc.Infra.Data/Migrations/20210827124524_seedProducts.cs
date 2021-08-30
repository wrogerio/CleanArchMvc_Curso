using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchMvc.Infra.Data.Migrations
{
    public partial class seedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "INSERT INTO Products (Name, Description, Price, Stock, Image, CategoryId) VALUES ('Caderno Espiral', 'Caderno Espiral 100 folhas', 12.34, 67, 'caderno.jpg', 1)");
            migrationBuilder.Sql(
                "INSERT INTO Products (Name, Description, Price, Stock, Image, CategoryId) VALUES ('Estojo Escolar', 'Estojo escolar infantil', 8.99, 14, 'estojo.jpg', 1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products");
        }
    }
}