using Microsoft.EntityFrameworkCore.Migrations;

namespace API_LuisaBot.Migrations
{
    public partial class UpdateUniqueIndexOrdem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Perguntas_Ordem",
                table: "Perguntas");

            migrationBuilder.CreateIndex(
                name: "IX_Perguntas_Ordem",
                table: "Perguntas",
                column: "Ordem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Perguntas_Ordem",
                table: "Perguntas");

            migrationBuilder.CreateIndex(
                name: "IX_Perguntas_Ordem",
                table: "Perguntas",
                column: "Ordem",
                unique: true);
        }
    }
}
