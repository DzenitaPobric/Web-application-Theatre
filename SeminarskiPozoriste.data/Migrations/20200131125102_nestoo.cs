using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SeminarskiPozoriste.data.Migrations
{
    public partial class nestoo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ulaznica_TipUlaznice_TipUlazniceID",
                table: "Ulaznica");

            migrationBuilder.DropTable(
                name: "TipUlaznice");

            migrationBuilder.DropColumn(
                name: "Cijena",
                table: "Ulaznica");

            migrationBuilder.RenameColumn(
                name: "TipUlazniceID",
                table: "Ulaznica",
                newName: "SjedisteID");

            migrationBuilder.RenameIndex(
                name: "IX_Ulaznica_TipUlazniceID",
                table: "Ulaznica",
                newName: "IX_Ulaznica_SjedisteID");

            migrationBuilder.AddColumn<decimal>(
                name: "Cijena",
                table: "Prikazivanje",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Komentar",
                columns: table => new
                {
                    KomentarID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sadrzaj = table.Column<string>(nullable: true),
                    VrijemeKreiranja = table.Column<DateTime>(nullable: false),
                    Odobren = table.Column<bool>(nullable: false),
                    KupacID = table.Column<int>(nullable: false),
                    PredstavaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komentar", x => x.KomentarID);
                    table.ForeignKey(
                        name: "FK_Komentar_Kupac_KupacID",
                        column: x => x.KupacID,
                        principalTable: "Kupac",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Komentar_Predstava_PredstavaID",
                        column: x => x.PredstavaID,
                        principalTable: "Predstava",
                        principalColumn: "PredstavaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Komentar_KupacID",
                table: "Komentar",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_Komentar_PredstavaID",
                table: "Komentar",
                column: "PredstavaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ulaznica_Sjediste_SjedisteID",
                table: "Ulaznica",
                column: "SjedisteID",
                principalTable: "Sjediste",
                principalColumn: "SjedisteID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ulaznica_Sjediste_SjedisteID",
                table: "Ulaznica");

            migrationBuilder.DropTable(
                name: "Komentar");

            migrationBuilder.DropColumn(
                name: "Cijena",
                table: "Prikazivanje");

            migrationBuilder.RenameColumn(
                name: "SjedisteID",
                table: "Ulaznica",
                newName: "TipUlazniceID");

            migrationBuilder.RenameIndex(
                name: "IX_Ulaznica_SjedisteID",
                table: "Ulaznica",
                newName: "IX_Ulaznica_TipUlazniceID");

            migrationBuilder.AddColumn<float>(
                name: "Cijena",
                table: "Ulaznica",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "TipUlaznice",
                columns: table => new
                {
                    TipUlazniceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipUlaznice", x => x.TipUlazniceID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Ulaznica_TipUlaznice_TipUlazniceID",
                table: "Ulaznica",
                column: "TipUlazniceID",
                principalTable: "TipUlaznice",
                principalColumn: "TipUlazniceID",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
