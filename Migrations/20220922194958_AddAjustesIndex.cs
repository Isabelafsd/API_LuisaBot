using Microsoft.EntityFrameworkCore.Migrations;

namespace API_LuisaBot.Migrations
{
    public partial class AddAjustesIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ordem",
                table: "Perguntas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Temas_Ordem",
                table: "Temas",
                column: "Ordem",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Respostas_Ordem",
                table: "Respostas",
                column: "Ordem",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Perguntas_Ordem",
                table: "Perguntas",
                column: "Ordem",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Temas_Ordem",
                table: "Temas");

            migrationBuilder.DropIndex(
                name: "IX_Respostas_Ordem",
                table: "Respostas");

            migrationBuilder.DropIndex(
                name: "IX_Perguntas_Ordem",
                table: "Perguntas");

            migrationBuilder.DropColumn(
                name: "Ordem",
                table: "Perguntas");
        }
    }
}
