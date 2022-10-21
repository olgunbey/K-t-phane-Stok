using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ornek11.Migrations
{
    public partial class Mig_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kitaplar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KitapAD = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kitaplar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KitapAciklama",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    KitapAcciklama = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitapAciklama", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KitapAciklama_Kitaplar_ID",
                        column: x => x.ID,
                        principalTable: "Kitaplar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KitaplarFiyatOZ",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    KitapFiyat = table.Column<int>(type: "int", nullable: false),
                    KitapStok = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitaplarFiyatOZ", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KitaplarFiyatOZ_Kitaplar_ID",
                        column: x => x.ID,
                        principalTable: "Kitaplar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KitapAciklama");

            migrationBuilder.DropTable(
                name: "KitaplarFiyatOZ");

            migrationBuilder.DropTable(
                name: "Kitaplar");
        }
    }
}
