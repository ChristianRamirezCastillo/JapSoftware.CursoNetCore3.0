using Microsoft.EntityFrameworkCore.Migrations;

namespace Ejemplo01.Migrations
{
    public partial class AgregarRutaFoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Rutafoto",
                table: "Amigos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rutafoto",
                table: "Amigos");
        }
    }
}
