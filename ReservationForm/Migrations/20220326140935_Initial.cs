using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationForm.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RezervasyonResults",
                columns: table => new
                {
                    rezervasyonResultsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rezervasyonYapilabilir = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RezervasyonResults", x => x.rezervasyonResultsId);
                });

            migrationBuilder.CreateTable(
                name: "Rezervasyons",
                columns: table => new
                {
                    rezervasyonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RezervasyonYapilacakKisiSayisi = table.Column<int>(type: "int", nullable: false),
                    KisilerFarkliVagonlaraYerlestirilebilir = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervasyons", x => x.rezervasyonId);
                });

            migrationBuilder.CreateTable(
                name: "YerlesimAyrinti",
                columns: table => new
                {
                    yerlesimAyrintiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VagonAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KisiSayisi = table.Column<int>(type: "int", nullable: false),
                    rezervasyonResultsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YerlesimAyrinti", x => x.yerlesimAyrintiId);
                    table.ForeignKey(
                        name: "FK_YerlesimAyrinti_RezervasyonResults_rezervasyonResultsId",
                        column: x => x.rezervasyonResultsId,
                        principalTable: "RezervasyonResults",
                        principalColumn: "rezervasyonResultsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tren",
                columns: table => new
                {
                    trenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rezervasyonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tren", x => x.trenId);
                    table.ForeignKey(
                        name: "FK_Tren_Rezervasyons_rezervasyonId",
                        column: x => x.rezervasyonId,
                        principalTable: "Rezervasyons",
                        principalColumn: "rezervasyonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vagonlar",
                columns: table => new
                {
                    vagonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kapasite = table.Column<int>(type: "int", nullable: false),
                    DolulukAdeti = table.Column<int>(type: "int", nullable: false),
                    trenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vagonlar", x => x.vagonId);
                    table.ForeignKey(
                        name: "FK_Vagonlar_Tren_trenId",
                        column: x => x.trenId,
                        principalTable: "Tren",
                        principalColumn: "trenId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tren_rezervasyonId",
                table: "Tren",
                column: "rezervasyonId");

            migrationBuilder.CreateIndex(
                name: "IX_Vagonlar_trenId",
                table: "Vagonlar",
                column: "trenId");

            migrationBuilder.CreateIndex(
                name: "IX_YerlesimAyrinti_rezervasyonResultsId",
                table: "YerlesimAyrinti",
                column: "rezervasyonResultsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vagonlar");

            migrationBuilder.DropTable(
                name: "YerlesimAyrinti");

            migrationBuilder.DropTable(
                name: "Tren");

            migrationBuilder.DropTable(
                name: "RezervasyonResults");

            migrationBuilder.DropTable(
                name: "Rezervasyons");
        }
    }
}
