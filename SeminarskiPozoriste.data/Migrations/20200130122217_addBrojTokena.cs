using Microsoft.EntityFrameworkCore.Migrations;

namespace SeminarskiPozoriste.data.Migrations
{
    public partial class addBrojTokena : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrojTokena",
                table: "Kupac",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrojTokena",
                table: "Kupac");
        }
    }
}
