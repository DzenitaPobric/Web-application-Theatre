using Microsoft.EntityFrameworkCore.Migrations;

namespace SeminarskiPozoriste.data.Migrations
{
    public partial class addkratkiSadrzaj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KratkiSadrzaj",
                table: "Novosti",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KratkiSadrzaj",
                table: "Novosti");
        }
    }
}
