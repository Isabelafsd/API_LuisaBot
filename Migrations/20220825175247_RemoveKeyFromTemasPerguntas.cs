using Microsoft.EntityFrameworkCore.Migrations;

namespace API_LuisaBot.Migrations
{
    public partial class RemoveKeyFromTemasPerguntas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TemasPerguntas",
                table: "TemasPerguntas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TemasPerguntas",
                table: "TemasPerguntas",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TemasPerguntas_PerguntaId",
                table: "TemasPerguntas",
                column: "PerguntaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TemasPerguntas",
                table: "TemasPerguntas");

            migrationBuilder.DropIndex(
                name: "IX_TemasPerguntas_PerguntaId",
                table: "TemasPerguntas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TemasPerguntas",
                table: "TemasPerguntas",
                columns: new[] { "PerguntaId", "TemaId" });
        }
    }
}
