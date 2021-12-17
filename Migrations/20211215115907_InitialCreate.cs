using Microsoft.EntityFrameworkCore.Migrations;

namespace monedas.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Monedas",
                columns: table => new
                {
                    moneda = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ValorActual = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorMax = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monedas", x => x.moneda);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Monedas");
        }
    }
}
