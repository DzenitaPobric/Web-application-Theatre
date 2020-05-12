using Microsoft.EntityFrameworkCore.Migrations;

namespace SeminarskiPozoriste.data.Migrations
{
    public partial class prikUUlaz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrojDostupnihMjesta",
                table: "Prikazivanje");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrojDostupnihMjesta",
                table: "Prikazivanje",
                nullable: false,
                defaultValue: 0);
        }
    }
}
