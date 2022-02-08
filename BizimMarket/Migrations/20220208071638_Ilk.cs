using Microsoft.EntityFrameworkCore.Migrations;

namespace BizimMarket.Migrations
{
    public partial class Ilk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Urunler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ResimYolu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KategoriId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urunler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Urunler_Kategoriler_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategoriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kategoriler",
                columns: new[] { "Id", "Ad" },
                values: new object[] { 1, "Atıştırmalık" });

            migrationBuilder.InsertData(
                table: "Kategoriler",
                columns: new[] { "Id", "Ad" },
                values: new object[] { 2, "Dondurma" });

            migrationBuilder.InsertData(
                table: "Kategoriler",
                columns: new[] { "Id", "Ad" },
                values: new object[] { 3, "Fırın" });

            migrationBuilder.InsertData(
                table: "Urunler",
                columns: new[] { "Id", "Ad", "Fiyat", "KategoriId", "ResimYolu" },
                values: new object[,]
                {
                    { 1, "Kinder Joy", 7.90m, 1, "KinderJoy.jpg" },
                    { 2, "Toblerone Sütlü Çikolata 100g", 18.90m, 1, "Toblerone.jpg" },
                    { 3, "Tadelle Fındık Dolgulu Sütlü Çikolata 30g", 4.90m, 1, "Tadelle.jpg" },
                    { 4, "Algida Maraş Usulü Sade Çikolata Dondurma 500ml ", 28.50m, 2, "AlgidaMaras.jpg" },
                    { 5, "Carte d'Or Selection Meyve Şöleni 850ml ", 36.90m, 2, "MeyveSoleni.jpg" },
                    { 6, "Minik Sandviç 10'lu ", 17.90m, 3, "MinikSandvic.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_KategoriId",
                table: "Urunler",
                column: "KategoriId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Urunler");

            migrationBuilder.DropTable(
                name: "Kategoriler");
        }
    }
}
