using Microsoft.EntityFrameworkCore.Migrations;

namespace API_LuisaBot.Migrations
{
    public partial class RemovendoCampoTemaDeSugestoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tema",
                table: "Sugestoes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tema",
                table: "Sugestoes",
                type: "text",
                nullable: true);
        }
    }
}
