using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SeminarskiPozoriste.data.Migrations
{
    public partial class druga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NagradnaIgra",
                columns: table => new
                {
                    NagradnaIgraID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    Pocetak = table.Column<DateTime>(nullable: false),
                    Kraj = table.Column<DateTime>(nullable: false),
                    AdminID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NagradnaIgra", x => x.NagradnaIgraID);
                    table.ForeignKey(
                        name: "FK_NagradnaIgra_Admin_AdminID",
                        column: x => x.AdminID,
                        principalTable: "Admin",
                        principalColumn: "AdminID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "KupacNagradnaIgra",
                columns: table => new
                {
                    KupacNagradnaIgraID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KupacID = table.Column<int>(nullable: false),
                    NagradnaIgraID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KupacNagradnaIgra", x => x.KupacNagradnaIgraID);
                    table.ForeignKey(
                        name: "FK_KupacNagradnaIgra_Kupac_KupacID",
                        column: x => x.KupacID,
                        principalTable: "Kupac",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_KupacNagradnaIgra_NagradnaIgra_NagradnaIgraID",
                        column: x => x.NagradnaIgraID,
                        principalTable: "NagradnaIgra",
                        principalColumn: "NagradnaIgraID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KupacNagradnaIgra_KupacID",
                table: "KupacNagradnaIgra",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_KupacNagradnaIgra_NagradnaIgraID",
                table: "KupacNagradnaIgra",
                column: "NagradnaIgraID");

            migrationBuilder.CreateIndex(
                name: "IX_NagradnaIgra_AdminID",
                table: "NagradnaIgra",
                column: "AdminID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KupacNagradnaIgra");

            migrationBuilder.DropTable(
                name: "NagradnaIgra");
        }
    }
}
