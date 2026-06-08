using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PopravkaBa.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdminVerifikacijaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
    name: "AdminVerificirao",
    table: "AspNetUsers",
    type: "boolean",
    nullable: false,
    defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
    name: "AdminVerificirao",
    table: "AspNetUsers");
        }
    }
}
