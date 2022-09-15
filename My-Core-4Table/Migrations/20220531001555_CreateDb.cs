using Microsoft.EntityFrameworkCore.Migrations;

namespace My_Core_4Table.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personellers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ADSOYAD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YAS = table.Column<int>(type: "int", nullable: false),
                    CINSIYET = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TOPLAMCALISMA = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personellers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Subelers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ADI = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    KONUM = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    YILLIKCIRO = table.Column<int>(type: "int", nullable: false),
                    TOPLAMCALISAN = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subelers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Toptancilars",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ADISOYADI = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    KONUMU = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TELEFONNO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TOPLAMCALISMA = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toptancilars", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Urunlers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ADI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FIYAT = table.Column<int>(type: "int", nullable: false),
                    MARKA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EKOZELLIKLER = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urunlers", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personellers");

            migrationBuilder.DropTable(
                name: "Subelers");

            migrationBuilder.DropTable(
                name: "Toptancilars");

            migrationBuilder.DropTable(
                name: "Urunlers");
        }
    }
}
