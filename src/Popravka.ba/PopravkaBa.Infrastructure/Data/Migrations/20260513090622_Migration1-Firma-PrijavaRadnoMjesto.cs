using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PopravkaBa.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration1FirmaPrijavaRadnoMjesto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusPrijave",
                table: "PrijavaRadnoMjesto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EmailPrimalac",
                table: "EmailNotifikacijaOglasa",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "OtvorenoDo",
                table: "AspNetUsers",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "OtvorenoOd",
                table: "AspNetUsers",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VelicinaFirme",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusPrijave",
                table: "PrijavaRadnoMjesto");

            migrationBuilder.DropColumn(
                name: "EmailPrimalac",
                table: "EmailNotifikacijaOglasa");

            migrationBuilder.DropColumn(
                name: "OtvorenoDo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OtvorenoOd",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "VelicinaFirme",
                table: "AspNetUsers");
        }
    }
}
