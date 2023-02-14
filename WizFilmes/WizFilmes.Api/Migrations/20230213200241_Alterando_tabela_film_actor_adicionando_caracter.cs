using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WizFilmes.Api.Migrations
{
    public partial class Alterando_tabela_film_actor_adicionando_caracter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Character",
                table: "Actors");

            migrationBuilder.AddColumn<string>(
                name: "Character",
                table: "FilmsActor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "FilmsActor",
                keyColumn: "Id",
                keyValue: 1,
                column: "Character",
                value: "Jiraya");

            migrationBuilder.UpdateData(
                table: "FilmsActor",
                keyColumn: "Id",
                keyValue: 2,
                column: "Character",
                value: "Maverick");

            migrationBuilder.UpdateData(
                table: "FilmsActor",
                keyColumn: "Id",
                keyValue: 3,
                column: "Character",
                value: "Capitao do soldado Ryan");

            migrationBuilder.UpdateData(
                table: "FilmsActor",
                keyColumn: "Id",
                keyValue: 4,
                column: "Character",
                value: "Mulher maravilha");

            migrationBuilder.UpdateData(
                table: "FilmsActor",
                keyColumn: "Id",
                keyValue: 5,
                column: "Character",
                value: "Lara Croft");

            migrationBuilder.UpdateData(
                table: "FilmsActor",
                keyColumn: "Id",
                keyValue: 6,
                column: "Character",
                value: "Ocean sister");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Character",
                table: "FilmsActor");

            migrationBuilder.AddColumn<string>(
                name: "Character",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Character",
                value: "Indiana Jones");

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Character",
                value: "Maverick");

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3,
                column: "Character",
                value: " Capitão John H. Miller ");

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 4,
                column: "Character",
                value: "Mulher Maravilha");

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 5,
                column: "Character",
                value: "Lara Croft");

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 6,
                column: "Character",
                value: "Debbie Ocean");
        }
    }
}
