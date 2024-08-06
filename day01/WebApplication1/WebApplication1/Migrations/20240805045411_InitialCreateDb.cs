using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dosens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nip = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dosens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Matkuls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sks = table.Column<int>(type: "int", nullable: false),
                    PengajarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matkuls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matkuls_Dosens_PengajarId",
                        column: x => x.PengajarId,
                        principalTable: "Dosens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mahasiswas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NPM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatKulId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mahasiswas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mahasiswas_Matkuls_MatKulId",
                        column: x => x.MatKulId,
                        principalTable: "Matkuls",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mahasiswas_MatKulId",
                table: "Mahasiswas",
                column: "MatKulId");

            migrationBuilder.CreateIndex(
                name: "IX_Matkuls_PengajarId",
                table: "Matkuls",
                column: "PengajarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mahasiswas");

            migrationBuilder.DropTable(
                name: "Matkuls");

            migrationBuilder.DropTable(
                name: "Dosens");
        }
    }
}
