using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WizFilmes.Api.Migrations
{
    public partial class AtualizandotableFilmActorRelacionamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmsActor_Actors_FilmId",
                table: "FilmsActor");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmsActor_Films_ActorId",
                table: "FilmsActor");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmsActor_Actors_ActorId",
                table: "FilmsActor",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmsActor_Films_FilmId",
                table: "FilmsActor",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmsActor_Actors_ActorId",
                table: "FilmsActor");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmsActor_Films_FilmId",
                table: "FilmsActor");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmsActor_Actors_FilmId",
                table: "FilmsActor",
                column: "FilmId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmsActor_Films_ActorId",
                table: "FilmsActor",
                column: "ActorId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
