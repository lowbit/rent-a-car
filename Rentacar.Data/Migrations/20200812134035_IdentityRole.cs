using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rentacar.Data.Migrations
{
    public partial class IdentityRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tipovi_korisnickog_nalogas_TipId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Tipovi_korisnickog_nalogas");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TipId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Lozinka",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TipId",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Lozinka",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Tipovi_korisnickog_nalogas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    Permisije = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipovi_korisnickog_nalogas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TipId",
                table: "AspNetUsers",
                column: "TipId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tipovi_korisnickog_nalogas_TipId",
                table: "AspNetUsers",
                column: "TipId",
                principalTable: "Tipovi_korisnickog_nalogas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
